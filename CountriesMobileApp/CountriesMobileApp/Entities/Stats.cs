using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesMobileApp.Entities
{
    public class Stats
    {
        public int elapsed_time { get; set; }
        public int nb_characters { get; set; }
        public int nb_tokens { get; set; }
        public int nb_tus { get; set; }
        public int nb_tus_failed { get; set; }
    }
}
