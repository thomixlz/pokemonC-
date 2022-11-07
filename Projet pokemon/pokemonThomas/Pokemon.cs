using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonThomas
{
    internal class Pokemon
    {
        public string Name {get; set; }
        public int PointDeVieActuel { get; set; }
        public int PointDeVieMax { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }
        public int NiveauActuel { get; set; }
        public int ExperienceActuel { get; set; }

        public int ExperienceMax { get; set; }


        //////////////////////////////////////////

        public Pokemon()
        {

        }

        public Pokemon(string name, int pointDeVieActuel, int pointDeVieMax, int attaque, int defense, int vitesse, int niveauActuel, int experienceActuel, int experienceMax)
        {
            Name = name;
            PointDeVieActuel = pointDeVieActuel;    
            PointDeVieMax = pointDeVieMax;  
            Attaque = attaque;
            Defense = defense;  
            Vitesse = vitesse;
            NiveauActuel = niveauActuel;
            ExperienceActuel = experienceActuel;
            ExperienceMax = experienceMax;
        }


        /////////////////////////////////////////////
        
        // ATTAQUER ENNEMIE
        public void Attaquer(int targetPointDeVie, int targetDefense, int targetAttaque)

            // Mon système de combat est simple. La vitesse n'est pas utile en combat, la défense divisé par 2 = les dégats absorbé, l'attaque du pokémon sont les point de vie perdu.
            // Tout les pokémons ont 100 point de vie, mais chacun à des stats précis dans leurs ATTAQUE / DEFENSE
        
        
        {
            int degatPur = Attaque-(targetDefense/2);

            int nouveauPointDeVieTarget = targetPointDeVie - degatPur;

            Console.WriteLine("Vous attaquez le Pokémon adverse avec " + degatPur + " de dégats  ! Il lui reste " + nouveauPointDeVieTarget + " de vie !");

            if (nouveauPointDeVieTarget <= 0)
            {
                Console.WriteLine("Le combat est remporté !");
                GainXP(); // Gain d'xp
                PossibleCapture(); // Permet la capture du pokémon
            } 
            else
            {
                RecevoirAttaque(targetAttaque);
            }
        }


        // RECEVOIR DES DÉGATS APRES ATTAQUE
        public void RecevoirAttaque(int targetAttaque)
        {
            int AttaquePurEnnemy = targetAttaque - (Defense / 2);

            PointDeVieActuel -= AttaquePurEnnemy;

            Console.WriteLine("Vous subissez une attaque à " +  AttaquePurEnnemy + "de dégats ! Il vous reste " + PointDeVieActuel + " point de vie !");

            if (PointDeVieActuel <= 0)
            {
                GameOver();
            }
        }

        // POTION / HEAL PENDANT FIGHT
        public void Potion() 
        {

            var maPotion = 25; // Potion donne 25 de vie au Pokémon pendant le combat

            if(PointDeVieActuel < PointDeVieMax)
            {
                PointDeVieActuel += maPotion;

                if(PointDeVieActuel > PointDeVieMax)
                {
                    PointDeVieActuel = PointDeVieMax;
                    Console.WriteLine("Votre Pokémon à reçu du soin ! +" + maPotion + " point de vie ! Total actuel =" + PointDeVieActuel + "/" + PointDeVieMax);
                }
            }
            else
            {
                Console.WriteLine("!:WARN:! Votre Pokémon possède déjà tout ses point de vie !");
            }

        }

        // FUIR LE COMBAT
        public void Fuir()

            // Fuir un combat faire perdre 10 point de vie au Pokémon, mais bien sur on ne le dit pas avant la fuite :) 
        {

            Console.WriteLine("Vous avez fuis le combat ! Votre pokémon perd 10 points de vie");
            PointDeVieActuel -= 10;

            if (PointDeVieActuel <= 0)
            {
                GameOver();
            }
        }

        public void GainXP()

            // Chaque combat gagné fait remporté de l'expérience, ici on va gérer l'aspect des niveaux
            // Chaque niveau est plus long qu'un autre.
            // 1 Combat remporté = +50 XP
            // A chaque niveau +50XP sont nécéssaire pour monter de niveau.
            // C'est le seul moyen de remporté de l'expérience dans ce jeu.

        {

            // 100XP nécéssaire pour le premier niveau... +50 ..
            ExperienceActuel += 50;

            if (ExperienceActuel == ExperienceMax)
            {
                Console.WriteLine("Votre Pokémon à augmenté d'un niveau ! Il est actuellement niveau " + NiveauActuel);
                ExperienceMax += 50;

                PointDeVieMax += 10;
                Attaque += 2;
                Defense += 2;
                Vitesse += 2;
                NiveauActuel += 1;
                ExperienceActuel = 0;
            }
        }

        public void PossibleCapture(string maListeDePokemon, bool etatMenuPrincipal)
        {
            //En vu que le programme ne fonctionne pas au niveau de l'attaque la phase de test est impossible.
            //Ma logique est la suivante
            //J'initialise une liste qui comportera comme mes ennemies une liste pour mes pokémons (+ linq)
            //Une fois le combat perdu pour l'ennemie cette fonction s'applique et propose au joueur de partir ou de tenter la capture
            //Partir : mène vers le menu principal = combat fini
            //Capturer : essaye de capturer le pokémon avec une 1 chance sur 5
            //Si pokémon pas capturé il s'échappe et retour menu principal

            Console.WriteLine("Le pokémon est faible ! Il est possible de le capturer ! Que choisissez-vous ?");
            Console.WriteLine("1= CAPTURE");
            Console.WriteLine("2= SORTIR DU COMBAT");

            var choixCapture = Console.ReadLine();

            switch (choixCapture)
            {
                case "1": //CAPTURE

                    var random = new Random();
                    var listChiffreRandom = new List<object> { "1", "2", "3", "4", "5" };
                    int chiffreRandom = random.Next(listChiffreRandom.Count);
                    var choixRandomCapture = listChiffreRandom[chiffreRandom];


                    if (choixRandomCapture == "2")
                    {
                        Console.WriteLine("Pokémon capturé avec succès !");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Pokémon non capturé ! Il s'échappe ");
                        etatMenuPrincipal = true;
                        break;
                    }

                case "2":
                    Console.WriteLine("Vous quittez le combat");
                    etatMenuPrincipal = true;
                    break;

            }
        }

        // PARTIE PERDU (LOGIQUE A CRÉER DANS LE PROGRAM POUR PASSER ETAT GAME EN FALSE)
        public void GameOver()
        {
            Console.WriteLine("GAME OVER ! VOTRE POKEMON EST MORT");
        }













    }


}
