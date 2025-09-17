using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace M8_Project2.Models
{
    public class Trip
    {
        [Required]
        public int TripId { get; set; }
        [Required]
        public string Destination { get; set; } = string.Empty;
        [Required]
        public string Accommodation { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        public string? Activity1 { get; set; }
        public string? Activity2 { get; set; }
        public string? Activity3 { get; set; }
    }
}
