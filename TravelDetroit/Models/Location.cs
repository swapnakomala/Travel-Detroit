﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelDetroit.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PlaceId { get; set; }
        public string Address { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}