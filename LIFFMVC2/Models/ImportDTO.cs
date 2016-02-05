using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIFFMVC2.Models
{
    public class ImportDTO
    {
        //public int Id { get; set; }
        public string Subject { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        //New fields added to CSV
        public string Countries { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string TrailerURL { get; set; }
        public int RunningTime { get; set; }
        public string Subtitles { get; set; }
        public string Images { get; set; }
    }
}