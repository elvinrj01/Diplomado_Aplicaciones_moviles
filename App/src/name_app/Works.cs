using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Works
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int MissingDates { get; set; }
    }
}
