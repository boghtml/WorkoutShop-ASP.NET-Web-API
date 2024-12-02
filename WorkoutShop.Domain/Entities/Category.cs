﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutShop.Domain.Entities

{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }  // Зміна типу з Guid на int

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]

        public DateTime? UpdatedAt { get; set; }
    }
}
