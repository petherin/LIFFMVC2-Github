using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIFFMVC2.DataContexts;
using LIFFMVC2.Models;
using LIFFMVC2.Repository;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace LIFFMVC2.Areas.Admin.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private IFilmRepository repository = new SQLFilmRepository();

        // GET: Films
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            //http://joshclose.github.io/CsvHelper/

            Stream stream = file.InputStream;
            StreamReader streamReader = new StreamReader(stream);
            TextReader textReader = (TextReader)streamReader;

            var csv = new CsvHelper.CsvReader(textReader);
            List<ImportDTO> listOfDTOs = new List<ImportDTO>();
            while (csv.Read())
            {
                ImportDTO record  = csv.GetRecord<ImportDTO>();
                listOfDTOs.Add(record);
            }

            //Map DTO to models
            foreach (ImportDTO item in listOfDTOs)
            {
               

                //Get countries
                List<string> countries = item.Countries.Split(new char[] { '|' }).ToList();
                Collection<Country> countryCollection = new Collection<Country>();
                foreach (string countryName in countries)
                {
                    countryCollection.Add(new Country { Name = countryName });
                }


                //Get start and end times
                DateTime start = DateTime.ParseExact(item.StartDate + " " + item.StartTime, "dd/MM/yyyy HH:mm", 
                    System.Globalization.CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact(item.EndDate + " " + item.EndTime, "dd/MM/yyyy HH:mm",
                                System.Globalization.CultureInfo.InvariantCulture);

                Film newFilm = new Film();
                newFilm.Country = countryCollection;

                TimeSlot slot = new TimeSlot();
                slot.StartTime = start;
                slot.EndTime = end;


            }
            return View("Index");
            
        }

        protected override void Dispose(bool disposing)
        {
            if (repository != null)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
