﻿using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
