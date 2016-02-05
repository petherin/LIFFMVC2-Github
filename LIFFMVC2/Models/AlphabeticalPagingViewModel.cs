using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LIFFMVC2.Models
{
    public class AlphabeticalPagingViewModel
    {
        public List<string> Alphabet
        {
            get
            {
                var alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList();
                alphabet.Insert(0, "All");
                alphabet.Insert(1, "0-9");
                return alphabet;
            }
        }
        public List<string> FirstLetters { get; set; }
        public string SelectedLetter { get; set; }
        public bool NamesStartWithNumbers
        {
            get
            {
                var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());
                return FirstLetters.Intersect(numbers).Any();
            }
        }

        public List<Film> Films { get; set; }
        //Copied Film Model - keep in sync whenever model or viewmodel changes
        //public int Id { get; set; }
        //public string Title { get; set; }
        //public int Year { get; set; }
        //public string Description { get; set; }
        //[DisplayName("Trailer")]
        //public string TrailerURL { get; set; }
        //public int RunningTime { get; set; }
        //public bool Subtitles { get; set; }

        ////Foreign keys
        //public Collection<int> DirectorID { get; set; }
        //public Collection<int> CountryID { get; set; }

        ////Navigation properties
        //public virtual Collection<Director> Director { get; set; }
        //public virtual Collection<Country> Country { get; set; }
        //public virtual Collection<TimeSlot> Slots { get; set; }
        //public virtual Collection<Venue> Venues { get; set; }
        //public virtual Collection<ImagePath> Images { get; set; }

        //public static explicit operator AlphabeticalPagingViewModel(Film film)
        //{
        //    return new AlphabeticalPagingViewModel
        //    {
        //        Id = film.Id,
        //        Title = film.Title,
        //        Year = film.Year,
        //        Description = film.Description,
        //        TrailerURL = film.TrailerURL,
        //        RunningTime = film.RunningTime,
        //        Subtitles = film.Subtitles,
        //        DirectorID = film.DirectorID,
        //        CountryID = film.CountryID,
        //        Director = film.Director,
        //        Country = film.Country,
        //        Slots = film.Slots,
        //        Venues = film.Venues,
        //        Images = film.Images,
        //    };
        //}

        //public static explicit operator Film(AlphabeticalPagingViewModel vm)
        //{
        //    return new Film
        //    {
        //        Id = vm.Id,
        //        Title = vm.Title,
        //        Year = vm.Year,
        //        Description = vm.Description,
        //        TrailerURL = vm.TrailerURL,
        //        RunningTime = vm.RunningTime,
        //        Subtitles = vm.Subtitles,
        //        DirectorID = vm.DirectorID,
        //        CountryID = vm.CountryID,
        //        Director = vm.Director,
        //        Country = vm.Country,
        //        Slots = vm.Slots,
        //        Venues = vm.Venues,
        //        Images = vm.Images
        //    };
        //}
    }
}