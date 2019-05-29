using System.Collections.Generic;

namespace InfoCines.CommonModels
{
    public interface CinemaManager
    {
        void Update();

        List<CommonModels.UpcomingMovie> GetUpcomingFilms();

        List<CommonModels.Movie> GetCurrentFilms();

        List<CommonModels.Cinema> GetCinemas();
    }
}
