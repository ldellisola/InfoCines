using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CommonModels
{
    public enum CinemaChain
    {
        Cinemark,
        Hoyts,
        Village,
    }
    public class Cinema
    {
        public Cinema(CinemaChain chain)
        {
            this.Chain = chain;
        }
        public CinemaChain Chain { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string NearbyPublicTransit { get; set; }
        public Uri GoogleMaps { get; set; }
    }
}
