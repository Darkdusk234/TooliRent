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
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
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

        public async Task<IEnumerable<BookingDto>> GetBookingsWithLastDateWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           var bookings = await _unitOfWork.Bookings.GetBookingsWithLastDateWithinDateRangeAsync(startDate, endDate);
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

            if(!await _unitOfWork.Tools.ExistsAsync(createBookingDto.ToolId) ||
               await _userManager.FindByIdAsync(createBookingDto.UserId) == null)
            {
                return null;
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
            if (existingBooking == null || !await _unitOfWork.Categories.ExistsAsync(updateBookingDto.ToolId) || await _userManager.FindByIdAsync(updateBookingDto.UserId) == null)
            {
                return false;
            }

            _mapper.Map(updateBookingDto, existingBooking);

            await _unitOfWork.Bookings.UpdateAsync(existingBooking);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BookingExistsAsync(int bookingId)
        {
            return await _unitOfWork.Bookings.ExistsAsync(bookingId);
        }
    }
}
