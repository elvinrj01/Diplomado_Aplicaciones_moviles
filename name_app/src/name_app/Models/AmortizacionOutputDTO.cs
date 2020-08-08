using System;
using System.Collections.Generic;
using System.Text;

namespace name_app.Models
{
    public class AmortizacionOutputDTO
    {
        public int Periodo { get; set; }
        public double Cuota { get; set; }
        public double Capital { get; set; }
        public double Interes { get; set; }
        public double Balance { get; set; }
    }
}
