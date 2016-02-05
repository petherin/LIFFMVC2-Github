using LIFFMVC2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LIFFMVC2.Repository
{
    public interface IFilmRepository : IDisposable
    {
        IQueryable<Film> GetAllFilms();
        IQueryable<Director> GetAllDirectors();
        IQueryable<Country> GetAllCountries();
        IQueryable<Venue> GetAllVenues();
        IQueryable<TimeSlot> GetAllTimeSlots();

        IQueryable<Film> GetFilmsByDirector(int directorId);
        IQueryable<Film> GetFilmsByCountry(int countryId);
        IQueryable<Film> GetFilmsByYear(int year);
        IQueryable<Film> GetFilmsByTitle(string title);
        IQueryable<Film> GetFilmsByTimeSlot();
        IQueryable<Film> GetFilmsByVenue(int venueId);
        IQueryable<Film> GetFilmById(int ?filmId);

        IQueryable<TimeSlot> GetTimeSlotsByVenue(int venueId);
        IQueryable<TimeSlot> GetTimeSlotsByFilm(int filmId);
        IQueryable<TimeSlot> GetTimeSlotsByDirector(int directorId);
        IQueryable<TimeSlot> GetTimeSlotsByCountry(int countryId);
        IQueryable<TimeSlot> GetTimeSlotById(int slotId);

        IQueryable<Venue> GetVenuesByFilm(int filmId);
        IQueryable<Venue> GetVenueById(int venueId);

        IQueryable<Director> GetDirectorById(int directorId);
        IQueryable<Director> GetDirectorsByFilm(int filmId);
        IQueryable<Director> GetDirectorsByName(string name);

        IQueryable<Country> GetCountryById(int countryId);
        IQueryable<Country> GetCountryByName(string name);
        // IQueryable<Venue> GetVenuesByTimeSlot(int slotId);

        void AddFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
        void AddDirector(Director director);
        void UpdateDirector(Director director);
        void DeleteDirector(Director director);
        void AddVenue(Venue venue);
        void UpdateVenue(Venue venue);
        void DeleteVenue(Venue venue);
        void AddTimeSlot(TimeSlot timeSlot);
        void UpdateTimeSlot(TimeSlot timeSlot);
        void DeleteTimeSlot(TimeSlot timeSlot);

        void ModifyFilmState(Film film, EntityState state);
    }
}