using System;
using System.Collections.Generic;
using System.Text;
using InfoCines.CinemarkHoyts.Models;
using RestMethods;
using Newtonsoft.Json;
using System.Linq;

namespace InfoCines
{

    public class CinemarkHoytsCinema : CommonModels.CinemaManager
    {

        private CinemarkHoytsResponse response;

        public CinemarkHoytsCinema()
        {
            this.Update();
        }

        public void Update()
        {
            string str = new RestMethods.RestMethods(@"http://www.cinemarkhoyts.com.ar/billboard.ashx").Get();

            str = str.Remove(str.LastIndexOf(';'), 1).Replace("var jsonData = ", "");

            response = JsonConvert.DeserializeObject<CinemarkHoytsResponse>(str);
        }

        public List<CommonModels.UpcomingMovie> GetUpcomingFilms()
        {
            return ConvertUpcomingMovies();
        }

        public List<CommonModels.Movie> GetCurrentFilms()
        {
            return ConvertMovies();
        }

        public List<CommonModels.Cinema> GetCinemas()
        {
            List<CommonModels.Cinema> convertedCinemas = new List<CommonModels.Cinema>();
            foreach (var cinema in response.Cinemas)
                convertedCinemas.Add((CommonModels.Cinema)cinema);

            return convertedCinemas;
        }

        private List<CommonModels.UpcomingMovie> ConvertUpcomingMovies()
        {
            List<CommonModels.UpcomingMovie> convertedMovies = new List<CommonModels.UpcomingMovie>();


            foreach(var movie in response.FutureFilms)
            {
                var upcomming = new CommonModels.UpcomingMovie();

                upcomming.description = movie.Description;
                upcomming.name = movie.Name;
                upcomming.Poster = movie.UrlPoster;
                upcomming.releaseDate = movie.OpeningDate;
                upcomming.TrailerYoutube = movie.UrlTrailerYoutube;

                convertedMovies.Add(upcomming);
            }
            return convertedMovies;
        }

        private List<CommonModels.Movie> ConvertMovies()
        {
            List<CommonModels.Movie> convertedMovies = new List<CommonModels.Movie>();

            foreach (var movie in response.Films)
            {
                var common = new CommonModels.Movie();

                List<CommonModels.Cinema> temp = new List<CommonModels.Cinema>();

                foreach(var a in response.Cinemas.Where(x => movie.Cinemas.Contains(x.Id)))
                    temp.Add((CommonModels.Cinema)a);

                common.cinemas = temp;

                common.duration = (int)movie.Duration;
                common.name = movie.Name;
                common.originalName = "";
                common.showtimes = ConvertShowtimes(movie.Presentation);
                common.TrailerYoutube = movie.UrlTrailerYoutube;
                common.poster = movie.UrlPoster;

                convertedMovies.Add(common);
            }

            return convertedMovies;
        }

        private List<CommonModels.Showtime> ConvertShowtimes(List<MoviePresentation> presentations)
        {
            List<CommonModels.Showtime> output = new List<CommonModels.Showtime>();
            foreach (MoviePresentation presentation in presentations)
            {
                foreach(var cinema in presentation.CinemaList)
                {
                    var selectedCinema = (CommonModels.Cinema)response.Cinemas.FirstOrDefault(x => x.Id == cinema.CinemaID);
                    foreach (var room in cinema.Rooms)
                    {
                        var showtime = new CommonModels.Showtime();

                        showtime.cinema = selectedCinema;
                        showtime.Format = presentation.Format;
                        showtime.Language = presentation.Version.ToString(); // ARREGLAR
                        showtime.screeningType = presentation.Format;
                        showtime.start = room.Dtm;

                        output.Add(showtime);
                    }
                }


            }
            return output;
        }

    }

}
