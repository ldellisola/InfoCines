using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CommonModels
{

    public class Showtime
    {

        public DateTime start { get; set; }
        public Cinema cinema { get; set; }
        public string screeningType { get; set; } // Village: gold-class, 4D, standard, monster,  etc | Cinemark: 
        public string Language { get; set; } // Substitulada, Castellano
        public string Format { get; set; } // 2D, 3D

    }

}
