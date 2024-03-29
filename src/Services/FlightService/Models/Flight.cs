﻿using Core;

namespace FlightService.Models
{
    public class Flight : Entity
    {
        public Airport Loading { get; set; }
        public Guid LoadingId { get; set; }
        public DateTime DepartureDate { get; set; }

        public Airport Unloading { get; set; }
        public Guid UnloadingId { get; set; }
        public DateTime ArrivalDate { get; set; }

        public string Route { get; set; }
        public int Status {  get; set; }
    }
}
