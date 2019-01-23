using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class ProjectInStoreView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }
        public double? AvgGrade { get; set; }
        public double? Rank { get; set; }
    }
}
