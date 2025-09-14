using AutoMapper;
using TooliRent.Core.Interfaces;
using TooliRent.Services.DTOs.BookingDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Services.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public Task<IEnumerable<BookingDto>> GetBookingsByCancellationStatusAsync(bool isCancelled)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingDto>> GetBookingsByPickupStatusAsync(bool isPickedUp)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingDto>> GetBookingsByReturnStatusAsync(bool isReturned)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingDto>> GetBookingsByToolIdAsync(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingDto>> GetBookingsWithLastDateWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BookingExistsAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
