
namespace pokemonThomas
{
    internal class Program
    {
        // Bonjour, voici mon devoir concernant le jeu Pokémon.
        // J'ai eu énormément de difficulté avec le système de combat, j'ai pourtant tout compris,
        // l'utilisation des class, l'héritage, C#, je comprend tout mais je n'est pas la logique pour initaliser le combat
        // Beaucoup de flou dans ce devoir, et je suis déçu de devoir rajouter du code à quelque chose de non fonctionnel qui ma prit du temps à faire.
        // J'ai rajouter du coup le système de capture et la logique dans les classes. J'ai essayer de commenter au mieux cette version pour essayer de vous faire comprendre ma logique, GL :)
        // Je pense qu'avec plus de temps j'aurai pu evidemment réussir le projet. J'attend la correction avec impatience pour ce devoir. 
        // Déçu de moi même mais je ferai de mon mieux on prochain devoir et anticiperai le travail la prochaine fois que j'ai commencé bien trop tard.

        // PS: Pokémon Platine, Diamant et Perle sont les meilleurs Pokémon. 
        

        


        public static void Main(string[] args) {

            bool etatGame = false;


            // 1- Commentaire de début de partie permettant notamment le choix des starter Pokémon Platine. (Ousticram est le meilleur)
            Console.WriteLine("Bienvenue dans le RPG le moin réaliste de notre génération !");
            Console.WriteLine("=============================================");
            Console.WriteLine("Commencer votre aventure en choisissant un starter !");
            Console.WriteLine(" - Tortipouss");
            Console.WriteLine(" - Ouisticram");
            Console.WriteLine(" - Tiplouf");


            // 2 - Choix de  l'utilisateur du starter entre 3 pokémons. 
                //- Création de l'objet Tortipouss,Ouisticram ou Tiplouf enfant de la class Pokemon (j'aurai pu faire une class Starter enfant de Pokemon et les starters enfant de Starter)
                //- Annonce du choix 
                //- Ajout du choix dans un variable string starterChoiceName
                //- Passage de l'EtatGame en TRUE
                //- Début de la partie 

            var choixPokemonUtilisateur = Console.ReadLine();
            string starterChoiceName = "";
   
            switch (choixPokemonUtilisateur)
            {
                case "Tortipouss":
                    Tortipouss tortipouss = new Tortipouss();
                    Console.WriteLine("Vous avez choisi Tortipouss, Pokemon de type Plante !");
                    starterChoiceName = "Tortipouss";
                    etatGame = true;
                    break;
                case "Ouisticram":
                    Ouisticram ouisticram = new Ouisticram();
                    Console.WriteLine("Vous avez choisi Ouisticram, Pokemon de type Feu !");
                    starterChoiceName = "Ouisticram";
                    etatGame = true;
                    break;
                case "Tiplouf":
                    Tiplouf tiplouf = new Tiplouf();
                    Console.WriteLine("Vous avez choisi Tiplouf, Pokemon de type Eau !");
                    starterChoiceName = "Tiplouf";
                    etatGame = true;
                    break;
                default:
                    Console.WriteLine("Vous n'avez pas choisi de Pokémon ! Professeur Chen est furieux ! ENREVOIR !");
                    break;
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string pokemonChoisie = starterChoiceName; //Choix du pokémon starter
            bool menuChoice = false; // Permet l'initialisation du menu principal 
            bool menuCombat = false; // Permet l'inistalisation d'un combat
            bool menuStats = false; // Permet l'initialisation du menu stats

            bool choixPendantCombat = false; //Permet l'initialisation du menu de choix à chaque tour de combat
            bool choixAttaque = false; //Permet l'initialisation du choix ATTAQUE en combat (Attaque et reçoit Attaque)
            bool choixSoigner = false; //Permet l'initalisation du choix SOIGNER en combat (Soigne avec une potion)
            bool choixFuir = false; //Permet l'initialisation du choix FUIR en combat (Fuir quitte le combat et faire perdre de la vie au pokémon fuyant)


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // DEBUT DE LA PARTIE

            while (etatGame)
            {


                // Création de la liste des ennemies avec choix random parmit celle-ci
                var random = new Random();
                var listEnnemy = new List<object> { new Tortank(), new Dialga(), new Metamorph() };
                int chiffreRandom = random.Next(listEnnemy.Count);
                var choixRandomEnnemy = listEnnemy[chiffreRandom];

                // Menu principal s'affiche si TRUE
                menuChoice = true;


                // MENU PRINCIPAL 
                while (menuChoice)
                {
                    Console.WriteLine("--==-- MENU PRINCIPAL --=--");
                    Console.WriteLine(" ");
                    Console.WriteLine("1 = COMBATTRE");
                    Console.WriteLine("2 = SOIGNER");
                    Console.WriteLine("3 = STATISTIQUES");
                    Console.WriteLine("4 = QUITTER");


                    //Choix MENU PRINCIPAL
                        // 1- Combattre un pokémon
                        // 2- Soigner son pokémon au centre pokémon
                        // 3- Affiche stats du pokémon
                        // 4- Quitte le jeu
                    var choixMenuPrincipal = Console.ReadLine();

                    switch (choixMenuPrincipal)
                    {
                        case "1": //COMBATTRE
                            menuChoice = false;
                            menuCombat = true;
                            break;

                        case "2": //SOIGNER
                            if(pokemonChoisie == "Tortipouss" && new Tortipouss().PointDeVieActuel < new Tortipouss().PointDeVieMax)
                            {
                                new Tortipouss().PointDeVieActuel = new Tortipouss().PointDeVieMax;
                                Console.WriteLine("Votre Pokémon est actuellement soigné après voyage au centre pokémon !");
                            }
                            else if (pokemonChoisie == "Ouisticram" && new Ouisticram().PointDeVieActuel < new Ouisticram().PointDeVieMax)
                            {
                                new Ouisticram().PointDeVieActuel = new Ouisticram().PointDeVieMax;
                                Console.WriteLine("Votre Pokémon est actuellement soigné après voyage au centre pokémon !");
                            }
                            else if (pokemonChoisie == "Tiplouf" && new Tiplouf().PointDeVieActuel < new Tiplouf().PointDeVieMax)
                            {
                                new Tiplouf().PointDeVieActuel = new Tiplouf().PointDeVieMax;
                                Console.WriteLine("Votre Pokémon est actuellement soigné après voyage au centre pokémon !");
                            }
                            else
                            {
                                Console.WriteLine("Votre Pokémon à déjà toute sa vie :)");
                                Console.WriteLine(" ");
                                break;
                            }
                            break;



                        case "3": //STATS
                            menuChoice = false;
                            menuStats = true;
                            break;

                        case "4": //QUITTER
                            etatGame = false;
                            menuChoice = false;
                            Console.WriteLine("Merci d'avoir joué à Pokémon ! A bientôt !");
                            break;
                        default:
                            Console.WriteLine("Choix non valide");
                            break;

                        
                    }


                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                

                // Le Combat est non fonctionelle
                // Mon objectif était de faire un combat sous forme de tour
                // A chaque tour le joueur doit choisir quoi faire = Attaque(Ce fait attaquer en retour), Soin(Potion), Fuir(Perte 10HP)





                // Ouverture Menu Combat/Initialisation du combat
                while (menuCombat)
                {


                    if (choixRandomEnnemy == new Tortank())
                    {
                        Console.WriteLine("Un Tortank sauvage apparaît ! Pokédex : 'Tortank est un pokémon de type ea.... 'clap' !");
                        choixPendantCombat = true;



                        //Choix Attaquer
                        if (choixAttaque && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Attaquer(new Tortank().PointDeVieActuel, new Tortank().Defense, new Tortank().Attaque);
                        }
                        else if (choixAttaque && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Attaquer(new Tortank().PointDeVieActuel, new Tortank().Defense, new Tortank().Attaque);
                            choixPendantCombat = true;

                        }
                        else if (choixAttaque && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Attaquer(new Tortank().PointDeVieActuel, new Tortank().Defense, new Tortank().Attaque);
                            choixPendantCombat = true;
                        }
                        // Choix Soigner
                        else if (choixSoigner && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Potion();
                        }
                        else if (choixSoigner && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Potion();
                            choixPendantCombat = true;

                        }
                        else if (choixSoigner && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Potion();
                            choixPendantCombat = true;
                        }
                        // Choix Fuir
                        else if (choixFuir && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Fuir();
                            menuChoice = true;

                        }




                    }
                    else if (choixRandomEnnemy == new Dialga())
                    {
                        Console.WriteLine("Un Dialga sauvage apparaît ! Il sagit d'un pokémon légendaire, il semble être en fin de vie !");
                        choixPendantCombat = true;
                        //Choix Attaquer
                        if (choixAttaque  && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Attaquer(new Dialga().PointDeVieActuel, new Dialga().Defense, new Dialga().Attaque);
                            

                        }
                        else if (choixAttaque && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Attaquer(new Dialga().PointDeVieActuel, new Dialga().Defense, new Dialga().Attaque);
                            
                            choixPendantCombat = true;

                        }
                        else if (choixAttaque && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Attaquer(new Dialga().PointDeVieActuel, new Dialga().Defense, new Dialga().Attaque);
                            
                            choixPendantCombat = true;

                        }
                        // Choix Soigner
                        if (choixSoigner && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Potion();
                            choixPendantCombat = true;

                        }
                        else if (choixSoigner && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Potion();
                            choixPendantCombat = true;

                        }
                        else if (choixSoigner && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Potion();
                            choixPendantCombat = true;

                        }
                        // Choix Fuir
                        else if (choixFuir && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Fuir();
                            menuChoice = true;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Un Métamorph sauvage apparaît ! 'tintintintin' !");
                        choixPendantCombat = true;
                        menuChoice = false;

                        //Choix Attaquer
                        if (choixAttaque && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Attaquer(new Metamorph().PointDeVieActuel, new Metamorph().Defense, new Metamorph().Attaque);
                            choixPendantCombat = true;
                        }
                        else if (choixAttaque && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Attaquer(new Metamorph().PointDeVieActuel, new Metamorph().Defense, new Metamorph().Attaque);
                            choixPendantCombat = true;
                        }
                        else if (choixAttaque && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Attaquer(new Metamorph().PointDeVieActuel, new Metamorph().Defense, new Metamorph().Attaque);
                            choixPendantCombat = true;
                        }
                        // Choix Soigner
                        else if (choixAttaque && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Potion();
                            choixPendantCombat = true;
                        }
                        else if (choixAttaque && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Potion();
                            choixPendantCombat = true;
                        }
                        else if (choixAttaque && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Potion();
                            choixPendantCombat = true;
                        }
                        // Choix Fuir
                        else if (choixFuir && pokemonChoisie == "Tortipouss")
                        {
                            choixPendantCombat = false;
                            new Tortipouss().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Ouisticram")
                        {
                            choixPendantCombat = false;
                            new Ouisticram().Fuir();
                            menuChoice = true;

                        }
                        else if (choixFuir && pokemonChoisie == "Tiplouf")
                        {
                            choixPendantCombat = false;
                            new Tiplouf().Fuir();
                            menuChoice = true;

                        }
                    }





                }


                // MENU DE CHOIX PENDANT LE COMBAT

                while (choixPendantCombat)
                {
                    Console.WriteLine("A vous ! Que choisissez vous de faire ?");
                    Console.WriteLine("A = ATTAQUER");
                    Console.WriteLine("B = SE SOIGNER");
                    Console.WriteLine("C = FUIR");
                    var choixPendantCombatUtilisateur = Console.ReadLine();

                    switch (choixPendantCombatUtilisateur)
                    {
                        case "A":
                            choixAttaque = true;
                            choixPendantCombat = false;
                            break;
                        case "B":
                            choixSoigner = true;
                            choixPendantCombat = false;
                            break;
                        case "C":
                            choixFuir = true;
                            choixPendantCombat = false;
                            break;

                    }
                }

                // MENU DES STATS DU POKÉMON
                
                while (menuStats)
                {

                    if (pokemonChoisie == "Tortipouss")
                    {
                        Console.WriteLine("POINT DE VIE = " + new Tortipouss().PointDeVieActuel + "/" + new Tortipouss().PointDeVieMax);
                        Console.WriteLine("ATTAQUE = " + new Tortipouss().Attaque);
                        Console.WriteLine("DÉFENSE = " + new Tortipouss().Defense);
                        Console.WriteLine("VITESSE = " + new Tortipouss().Attaque);
                        Console.WriteLine("NIVEAU = " + new Tortipouss().NiveauActuel);
                        Console.WriteLine("XP = " + new Tortipouss().ExperienceActuel + "/" + new Tortipouss().ExperienceMax);

                    } 
                    else if (pokemonChoisie == "Ouisticram") 
                    {
                        Console.WriteLine("POINT DE VIE = " + new Ouisticram().PointDeVieActuel + "/" + new Ouisticram().PointDeVieMax);
                        Console.WriteLine("ATTAQUE = " + new Ouisticram().Attaque);
                        Console.WriteLine("DÉFENSE = " + new Ouisticram().Defense);
                        Console.WriteLine("VITESSE = " + new Ouisticram().Attaque);
                        Console.WriteLine("NIVEAU = " + new Ouisticram().NiveauActuel);
                        Console.WriteLine("XP = " + new Ouisticram().ExperienceActuel + "/" + new Ouisticram().ExperienceMax);
                    }
                    else if (pokemonChoisie == "Tiplouf")
                    {
                        Console.WriteLine("POINT DE VIE = " + new Tiplouf().PointDeVieActuel + "/" + new Tiplouf().PointDeVieMax);
                        Console.WriteLine("ATTAQUE = " + new Tiplouf().Attaque);
                        Console.WriteLine("DÉFENSE = " + new Tiplouf().Defense);
                        Console.WriteLine("VITESSE = " + new Tiplouf().Attaque);
                        Console.WriteLine("NIVEAU = " + new Tiplouf().NiveauActuel);
                        Console.WriteLine("XP = " + new Tiplouf().ExperienceActuel + "/" + new Tiplouf().ExperienceMax);
                    }

                    menuStats = false;
                    menuChoice = true;
                }



            }














             
        }

    }
}

