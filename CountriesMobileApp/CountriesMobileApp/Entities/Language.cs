using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesMobileApp.Entities
{
    public class Language
    {
        public string iso639_1 { get; set; }
        public string iso639_2 { get; set; }
        public string name { get; set; }
        public string nativeName { get; set; }

        public override string ToString()
        {
            return $"{iso639_1} - {name}";
        }
    }
}
