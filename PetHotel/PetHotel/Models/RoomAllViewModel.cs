﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class RoomAllViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Place { get; set; }

        public string Owner { get; set; }

        public decimal PricePerNight { get; set; }
    }
}
