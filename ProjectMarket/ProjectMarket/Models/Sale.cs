using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ProjectMarket.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Range(0.0,10000.0)]
        public double Price { get; set; }
        [Range(0,100)]
        public int ProjectsGrade { get; set; }
        public Tuple<double,double> MeetingLocation{ get; set; }
        [Range(1,5)]
        public int Rank { get; set; }
    }
}
