using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LIFFMVC2.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        [DisplayName("Trailer")]
        public string TrailerURL { get; set; }
        public int RunningTime { get; set; }
        public bool Subtitles { get; set; }

        //Foreign keys
        public Collection<int> DirectorID { get; set; }
        public Collection<int> CountryID { get; set; }

        //Navigation properties
        public virtual Collection<Director> Director { get; set; }
        public virtual Collection<Country> Country { get; set; }
        public virtual Collection<TimeSlot> Slots { get; set; }
        public virtual Collection<Venue> Venues { get; set; }
        public virtual Collection<ImagePath> Images { get; set; }

     
    }
}
