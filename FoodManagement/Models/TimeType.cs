﻿using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Models
{
    public class TimeType
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Time Type Name")]
        public string Name { get; set; }
    }
}