﻿namespace DataBaseService.Dtos
{
    public class ClothesReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }
        public string VendorCode { get; set; } = null!;
        public bool? Active { get; set; }
        public string Discription { get; set; } = null!;
        public int GenderId { get; set; }
    }
}
