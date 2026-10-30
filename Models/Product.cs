using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3_NguyenMinhHai.Models
{
    // thêm 1 lớp sản phẩm Product gồm Id, Name, Price, Description, CategoryId
    public class Product
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public decimal Price { get; set; }
        public string ? Description { get; set; }
        public int CategoryId { get; set; }
    }
}