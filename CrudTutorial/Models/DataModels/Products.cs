﻿using System.ComponentModel.DataAnnotations;

namespace CrudTutorial.Models.DataModels
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
    }
}
