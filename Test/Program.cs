using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            InfoCines.CinemarkHoytsCinema aa = new InfoCines.CinemarkHoytsCinema();

            var cines = aa.GetCinemas();

            var pelis = aa.GetCurrentFilms();

            var newPelis = aa.GetUpcomingFilms();

            
        }
    }
}
