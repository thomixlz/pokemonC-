using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pokemonThomas
{

    // Starter 
    internal class Tiplouf : Pokemon
    {
        public Tiplouf()
        {
            Name = "Tiplouf";
            PointDeVieActuel = 100;
            PointDeVieMax = 100;
            Attaque = 40;
            Defense = 20;
            Vitesse = 10;
            NiveauActuel = 1;
            ExperienceActuel = 0;
            ExperienceMax = 100;
        }
    }
}
