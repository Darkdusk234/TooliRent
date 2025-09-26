namespace TooliRent.Services.DTOs.BookingDtos
{
    public class AdminStatisticDto
    {
        public int TotalBookingsDuringDateRange { get; set; }
        public int TotalToolsBookedDuringDateRange { get; set; }
        public int TotalToolsInSystem { get; set; }
        public int TotalUsersInSystem { get; set; }
        public int TotalToolsAvailableNow { get; set; }
    }
}
