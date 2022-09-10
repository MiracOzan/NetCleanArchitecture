﻿using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual Brand? Brand { get; set; }

        public Model()
        {

        }
        public Model(string name, decimal dailyPrice, string ımageUrl, int brandId) : this()
        {
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = ımageUrl;
            BrandId = brandId;
        }
    }
}