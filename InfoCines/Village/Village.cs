using System;
using System.Collections.Generic;
using InfoCines.Village.Models.Showtime;
using InfoCines.Village.Models;
using RestMethods;
using InfoCines.CommonModels;

namespace InfoCines.Village
{
    public class Village : CommonModels.CinemaManager
    {

        private List<CinemaData> cinemas;
        private List<MovieData> movies;
        private Dictionary<MovieData, List<ShowtimeData>> showtimes= new Dictionary<MovieData, List<ShowtimeData>>();

        public Village(bool DownloadShowtimes = true)
        {

            Update();

            if (DownloadShowtimes)
            {
                foreach(MovieData  movie in movies)
                {
                    DownloadAllShowtimes(movie,movie.IsPreSell && DateTime.Now < movie.NextShowtime ? movie.NextShowtime : DateTime.Now);
                }
            }

        }

        public List<ShowtimeData> DownloadAllShowtimes(MovieData movie,DateTime date)
        {
            List<ShowtimeData> retValue = new List<ShowtimeData>();

            string address = @"https://www.villagecines.com/api/movies/" + movie.Id + "/showtimes?screen_type={{screenType}}&date=" + date.ToString("yyyy-MM-dd");

            var standard = new RestMethods.RestMethods(address.Replace("{{screenType}}", "standard")).Get<ShowtimeResponse>().Data;
            var monster = new RestMethods.RestMethods(address.Replace("{{screenType}}", "monster")).Get<ShowtimeResponse>().Data;
            var goldClass = new RestMethods.RestMethods(address.Replace("{{screenType}}", "gold-class")).Get<ShowtimeResponse>().Data;                
            var fourthDimension = new RestMethods.RestMethods(address.Replace("{{screenType}}", "4d")).Get<ShowtimeResponse>().Data;

            retValue.AddRange(standard);
            retValue.AddRange(monster);
            retValue.AddRange(goldClass);
            retValue.AddRange(fourthDimension);

            if(!showtimes.ContainsKey(movie))
            {
                showtimes[movie] = retValue;
            }
            else
            {
                showtimes[movie].AddRange(retValue);
            }


            return retValue;
        }

        public List<Cinema> GetCinemas()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetCurrentFilms()
        {
            throw new NotImplementedException();
        }

        public List<UpcomingMovie> GetUpcomingFilms()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            cinemas = new RestMethods.RestMethods(@"https://www.villagecines.com/api/complexes").Get<CinemasResponse>().Data;
            movies = new RestMethods.RestMethods(@"https://www.villagecines.com/api/movies").Get<MoviesResponse>().Data;
        }
    }
}
