using System;
using System.ComponentModel.DataAnnotations;

namespace YMApp.Trips.Dtos
{
    public class CreateOrUpdateTripInput
    {
        [Required]
        public TripEditDto Trip { get; set; }
    }
}
