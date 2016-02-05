using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LIFFMVC2.Models
{
    public class Venue
    {
        public int Id { get; set; }
        [DisplayName("Venue")]
        public string Name { get; set; }

        //Navigation properties
        public virtual Collection<TimeSlot> Slots { get; set; }
        public virtual Collection<Film> Films { get; set; }
    }
    
}
