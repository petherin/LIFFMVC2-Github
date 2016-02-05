using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIFFMVC2.Models;
using LIFFMVC2.DataContexts;
using System.Data.Entity;

namespace LIFFMVC2.Repository
{
    public class SQLFilmRepository : IFilmRepository
    {
        IdentityDb identityDb = new IdentityDb();
        FilmsDb filmDb = new FilmsDb();

        #region Director
        public void AddDirector(Director director)
        {
            filmDb.Directors.Add(director);
            filmDb.SaveChanges();
        }

        public void DeleteDirector(Director director)
        {
            filmDb.Directors.Remove(director);
            filmDb.SaveChanges();
        }

        public IQueryable<Director> GetAllDirectors()
        {
            return filmDb.Directors;
        }

        public IQueryable<Director> GetDirectorById(int directorId)
        {
            return from director in filmDb.Directors
                   where director.Id == directorId
                   select director;
        }

        public IQueryable<Director> GetDirectorsByFilm(int filmId)
        {
            var film = GetFilmById(filmId);
            return from director in filmDb.Directors
                   where director.Films.Contains((Film)film)
                   select director;
        }

        public IQueryable<Director> GetDirectorsByName(string name)
        {
            return from director in filmDb.Directors
                   where director.Name.Contains(name)
                   select director;
        }

        public void UpdateDirector(Director director)
        {
            var tmpDirector = filmDb.Directors.Single(d => d.Id == director.Id);
            tmpDirector.Films = director.Films;
            tmpDirector.Name = director.Name;
            filmDb.SaveChanges();
        }

        #endregion

        #region Film
        public void AddFilm(Film film)
        {
            filmDb.Films.Add(film);
            filmDb.SaveChanges();
        }

        public void DeleteFilm(Film film)
        {
            filmDb.Films.Remove(film);
            filmDb.SaveChanges();
        }

        public IQueryable<Film> GetAllFilms()
        {
            return filmDb.Films;
        }

        public IQueryable<Film> GetFilmsByCountry(int countryId)
        {
            return from film in filmDb.Films
                   where film.CountryID.Contains(countryId)
                   select film;
        }

        public IQueryable<Film> GetFilmsByDirector(int directorId)
        {
            return from film in filmDb.Films
                   where film.DirectorID.Contains(directorId)
                   select film;
        }

        public IQueryable<Film> GetFilmsByTimeSlot()
        {
            // Change this to work with a date range
            throw new NotImplementedException();
        }

        public IQueryable<Film> GetFilmsByTitle(string title)
        {
            return from film in filmDb.Films
                   where film.Title.Contains(title)
                   select film;
        }

        public IQueryable<Film> GetFilmsByYear(int year)
        {
            return from film in filmDb.Films
                   where film.Year == year
                   select film;
        }

        public IQueryable<Film> GetFilmsByVenue(int venueId)
        {
            var venue = GetVenueById(venueId);
            return from film in filmDb.Films
                   where film.Venues.Contains((Venue)venue)
                   select film;
        }

        public IQueryable<Film> GetFilmById(int? filmId)
        {
            return from film in filmDb.Films
                   where film.Id == filmId
                   select film;
        }

        public void UpdateFilm(Film film)
        {
            var tmpFilm = filmDb.Films.Single(f => f.Id == film.Id);
            tmpFilm.Country = film.Country;
            tmpFilm.Description = film.Description;
            tmpFilm.Director = film.Director;
            tmpFilm.Images = film.Images;
            tmpFilm.Title = film.Title;
            tmpFilm.TrailerURL = film.TrailerURL;
            tmpFilm.Year = film.Year;
            tmpFilm.Slots = film.Slots;
            tmpFilm.Venues = film.Venues;
            filmDb.SaveChanges();
        }

        #endregion

        #region TimeSlot
        public void AddTimeSlot(TimeSlot timeSlot)
        {
            filmDb.Slots.Add(timeSlot);
            filmDb.SaveChanges();
        }

        public void DeleteTimeSlot(TimeSlot timeSlot)
        {
            filmDb.Slots.Remove(timeSlot);
            filmDb.SaveChanges();
        }

        public IQueryable<TimeSlot> GetAllTimeSlots()
        {
            return filmDb.Slots;
        }

        public IQueryable<TimeSlot> GetTimeSlotsByVenue(int venueId)
        {
            return from slot in filmDb.Slots
                   where slot.VenueID == venueId
                   select slot;
        }

        public IQueryable<TimeSlot> GetTimeSlotsByFilm(int filmId)
        {
            return from slot in filmDb.Slots
                   where slot.FilmID == filmId
                   select slot;
        }

        public IQueryable<TimeSlot> GetTimeSlotsByDirector(int directorId)
        {
            var director = GetDirectorById(directorId);
            return from slot in filmDb.Slots
                   where slot.Film.Director.Contains((Director)director)
                   select slot;
        }

        public IQueryable<TimeSlot> GetTimeSlotsByCountry(int countryId)
        {
            var country = GetCountryById(countryId);
            return from slot in filmDb.Slots
                   where slot.Film.Country.Contains((Country)country)
                   select slot;
        }

        public IQueryable<TimeSlot> GetTimeSlotById(int slotId)
        {
            return from slot in filmDb.Slots
                   where slot.Id == slotId
                   select slot;
        }

        public void UpdateTimeSlot(TimeSlot timeSlot)
        {
            var tmpSlot = filmDb.Slots.Single(s => s.Id == timeSlot.Id);
            tmpSlot.EndTime = timeSlot.EndTime;
            tmpSlot.Film = timeSlot.Film;
            tmpSlot.Selected = timeSlot.Selected;
            tmpSlot.StartTime = timeSlot.StartTime;
            tmpSlot.Venue = timeSlot.Venue;
            filmDb.SaveChanges();
        }
        #endregion

        #region Venue
        public void AddVenue(Venue venue)
        {
            filmDb.Venues.Add(venue);
            filmDb.SaveChanges();
        }

        public void DeleteVenue(Venue venue)
        {
            filmDb.Venues.Remove(venue);
            filmDb.SaveChanges();
        }

        public IQueryable<Venue> GetAllVenues()
        {
            return filmDb.Venues;
        }

        public IQueryable<Venue> GetVenueById(int venueId)
        {
            return from venue in filmDb.Venues
                   where venue.Id == venueId
                   select venue;
        }

        public void UpdateVenue(Venue venue)
        {
            var tmpVenue = filmDb.Venues.Single(v => v.Id == venue.Id);
            tmpVenue.Name = venue.Name;
            tmpVenue.Slots = venue.Slots;
            filmDb.SaveChanges();
        }

        public IQueryable<Venue> GetVenuesByFilm(int filmId)
        {
            var film = GetFilmById(filmId);
            return from venue in filmDb.Venues
                   where venue.Films.Contains((Film)film)
                   select venue;
        }

        //public IQueryable<Venue> GetVenuesByTimeSlot(int venueId)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Country
        public IQueryable<Country> GetAllCountries()
        {
            return filmDb.Countries;
        }

        public IQueryable<Country> GetCountryById(int countryId)
        {
            return from country in filmDb.Countries
                   where country.Id == countryId
                   select country;
        }

        public IQueryable<Country> GetCountryByName(string name)
        {
            return from country in filmDb.Countries
                   where country.Name == name
                   select country;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    identityDb.Dispose();
                    filmDb.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SQLFilmRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #region State
        public void ModifyFilmState(Film film, EntityState state)
        {
            filmDb.Entry(film).State = state;
            filmDb.SaveChanges();
        }
        #endregion
    }
}