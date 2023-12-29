using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
