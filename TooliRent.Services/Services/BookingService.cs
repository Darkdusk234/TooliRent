using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TooliRent.Core.Interfaces;
using TooliRent.Core.Models;
using TooliRent.Services.DTOs.BookingDtos;
using TooliRent.Services.DTOs.ToolDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> users)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = users;
        }

        public async Task<IEnumerable<BookingDto>> GetActiveBookingsAsync()
        {
            var bookings = await _unitOfWork.Bookings.GetActiveBookingsAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings); ;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto?> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            return booking != null ? _mapper.Map<BookingDto>(booking) : null;
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByPickupStatusAsync(bool isPickedUp)
        {
           var bookings = await _unitOfWork.Bookings.GetBookingsByPickupStatusAsync(isPickedUp);
           return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByReturnStatusAsync(bool isReturned)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsByReturnStatusAsync(isReturned);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByToolIdAsync(int toolId)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsByToolIdAsync(toolId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(string userId)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsActiveWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           var bookings = await _unitOfWork.Bookings.GetBookingsActiveWithinDateRangeAsync(startDate, endDate);
           return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            if(!await BookingExistsAsync(bookingId))
            {
                return false;
            }

            var bookingToCancel = await _unitOfWork.Bookings.GetByIdAsync(bookingId);

            if(bookingToCancel.IsCancelled || bookingToCancel.ReturnDate != null)
            {
                return false;
            }

            bookingToCancel.IsCancelled = true;
            await _unitOfWork.Bookings.UpdateAsync(bookingToCancel);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        //Update to check if tool is available for booking duration
        public async Task<BookingDto?> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var newBooking = _mapper.Map<Booking>(createBookingDto);

            foreach(var toolId in createBookingDto.ToolId)
            {
                if (!await _unitOfWork.Tools.ExistsAsync(toolId))
                {
                    return null;
                }
            }

            if (await _userManager.FindByIdAsync(createBookingDto.UserId) == null)
            {
                return null;
            }

            foreach (var toolId in createBookingDto.ToolId)
            {
                if ((await _unitOfWork.Bookings.GetActiveToolBookingWithinDateRange(createBookingDto.StartBookedDate, createBookingDto.LastBookedDate, toolId)).Count() != 0)
                {
                    return null;
                }
            }

            await _unitOfWork.Bookings.AddAsync(newBooking);
            await _unitOfWork.SaveChangesAsync();

            var createdBooking = await _unitOfWork.Bookings.GetByIdAsync(newBooking.Id);
            return _mapper.Map<BookingDto>(createdBooking);
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            if (!await BookingExistsAsync(bookingId))
            {
                return false;
            }

            await _unitOfWork.Bookings.DeleteAsync(bookingId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto updateBookingDto)
        {
            var existingBooking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);

            foreach(var toolId in updateBookingDto.ToolId)
            {
                if (!await _unitOfWork.Tools.ExistsAsync(toolId))
                {
                    return false;
                }
            }

            if (existingBooking == null || await _userManager.FindByIdAsync(updateBookingDto.UserId) == null ||
                existingBooking.IsCancelled || existingBooking.ReturnDate != null)
            {
                return false;
            }

            foreach (var toolId in updateBookingDto.ToolId)
            {
                var bookings = await _unitOfWork.Bookings.GetActiveToolBookingWithinDateRange(updateBookingDto.StartBookedDate, updateBookingDto.LastBookedDate, toolId);
                if(bookings.Count() != 1)
                {
                    return false;
                }

                if(bookings.FirstOrDefault().Id != bookingId)
                {
                    return false;
                }
            }

            _mapper.Map(updateBookingDto, existingBooking);

            await _unitOfWork.Bookings.UpdateAsync(existingBooking);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkBookingAsPickedUpAsync(int bookingId)
        {
            var existingBooking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);

            if (existingBooking == null || existingBooking.IsCancelled || existingBooking.IsPickedUp || existingBooking.ReturnDate != null)
            {
                return false;
            }

            existingBooking.IsPickedUp = true;
            await _unitOfWork.Bookings.UpdateAsync(existingBooking);
            await _unitOfWork.SaveChangesAsync();
            await SetToolAvailability(existingBooking.ToolId, false);
            return true;
        }

        public async Task<bool> MarkBookingAsReturnedAsync(int bookingId)
        {
            var existingBooking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);

            if (existingBooking == null || existingBooking.IsCancelled || !existingBooking.IsPickedUp || existingBooking.ReturnDate != null)
            {
                return false;
            }

            existingBooking.ReturnDate = DateTime.UtcNow;

            await _unitOfWork.Bookings.UpdateAsync(existingBooking);
            await _unitOfWork.SaveChangesAsync();
            await SetToolAvailability(existingBooking.ToolId, true);
            return true;
        }

       public async Task<bool> MarkLateReturnAsHandled(int id)
        {
            var existingBooking = await _unitOfWork.Bookings.GetByIdAsync(id);

            if(existingBooking == null || existingBooking.IsCancelled || existingBooking.ReturnDate == null ||
               existingBooking.ReturnDate !> existingBooking.LastBookedDate || existingBooking.LateReturnHandled)
            {
                return false;
            }

            existingBooking.LateReturnHandled = true;

            await _unitOfWork.Bookings.UpdateAsync(existingBooking);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookingDto>> GetNotHandledLateReturnedBookings()
        {
            var bookings = await _unitOfWork.Bookings.GetNotHandledLateReturnedBookings();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<bool> BookingExistsAsync(int bookingId)
        {
            return await _unitOfWork.Bookings.ExistsAsync(bookingId);
        }

        private async Task<bool> SetToolAvailability(IList<int> toolId, bool isAvailable)
        {
            IList<Tool> tools = new List<Tool>();
            foreach (var id in toolId)
            {
                var tool = await _unitOfWork.Tools.GetByIdAsync(id);

                if (tool == null)
                {
                    return false;
                }

                tools.Add(tool);
            }

            foreach (var tool in tools)
            {
                tool.Available = isAvailable;
                await _unitOfWork.Tools.UpdateAsync(tool);
            }
           
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
