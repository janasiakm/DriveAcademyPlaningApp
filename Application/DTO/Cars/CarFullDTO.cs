﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Cars
{       
    public class CarFullDTO
    { 
        public int CarId { get; set; }
       public string? Mark { get; set; } = "";
        public string? Model { get; set; } = "";
        public string? RejestractionNumber { get; set; } = "";
        public int ProductionYear { get; set; }
        public DateTime Modyfication { get; set; }

    }
    

}
