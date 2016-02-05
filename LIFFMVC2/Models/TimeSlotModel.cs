using System;

namespace LIFFMVC2.Models
{
    public class TimeSlot
    {
        public int Id  { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Selected { get; set; }

        //Foreign keys
        public int FilmID { get; set; }
        public int VenueID { get; set; }

        //Navigation properties
        public virtual Film Film { get; set; }
        public virtual Venue Venue { get; set; }

    }
    
}
