using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public float Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsLeft { get; set; }
    }
}
