using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Details { get; set; }
    }
}
