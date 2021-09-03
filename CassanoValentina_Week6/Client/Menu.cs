using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Client
{
    public class Menu
    {

        private static MainBL mainBL = new MainBL(new EFClientiRepository(), new EFPolizzeRepository());

        internal static void Start()
        {
            Console.WriteLine("** Avvio Programma **");

            char choice;

            do
            {
                Console.WriteLine("1- Aggiungi un nuovo cliente ");
                Console.WriteLine("2- Inserisci polizza ");
                Console.WriteLine("3- Visualizza le polizze di un cliente");
                Console.WriteLine("4- Posticipa la data di scadenza");
                Console.WriteLine("Premi Q per uscire");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AddNewCliente();
                        Console.WriteLine();
                        break;
                    case '2':
                        UpdatePolizza();
                        Console.WriteLine();
                        break;
                    case '3':
                        ShowPolizza();
                        Console.WriteLine();
                        break;
                    case '4':
                        UpdateDataScadenza();
                        Console.WriteLine();
                        break;

                    case 'Q':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                }
            }
            while (!(choice == 'Q'));

        }

        private static void ShowPolizza()
        {
            var pol = mainBL.FetchPolizze();
        }


        private static void ShowClienti()
        {
            var clienti = MainBL.FetchClienti();

            if (clienti.Count != 0)
            {
                Console.WriteLine("Clienti presenti nel sistema:");
                foreach (var c in clienti)
                {
                    Console.WriteLine($"Nome: {c.Nome} Cognome: {c.Cognome} Codice Fiscale: {c.CodFiscale} Polizza attiva: {c.Polizze.IdPolizze}");
                }
            }
            else
            {
                Console.WriteLine("\nNon ci sono clienti");
            }
        }


        public static object GetUtenteByCodFiscale(string codfiscale)
        {
            var cliente = mainBL.GetByCodiceFiscale(codfiscale);
            return cliente;
        }


        public static void AddNewCliente()
        {
            string nome, cognome, codfiscale;

            do
            {
                Console.Write("Inserisci il codice fiscale del nuovo cliente");
                codfiscale = Console.ReadLine();
            }
            while (codfiscale.Length != 16);

            if (GetUtenteByCodFiscale(codfiscale) == null)
            {
                do
                {
                    Console.WriteLine("Inserisci nome:");
                    nome = Console.ReadLine();
                }
                while (nome.Length == 0);

                do
                {
                    Console.WriteLine("Inserisci cognome:");
                    cognome = Console.ReadLine();

                }
                while (cognome.Length == 0);

                Clienti newClienti = new Clienti
                {
                    Cognome = cognome,
                    Nome = nome,
                    CodFiscale = codfiscale
                };

                mainBL.AddClienti(newClienti);


            }
        }

        private static void UpdatePolizza()
        {
            string codfiscale, edittipopolizza;
            Console.WriteLine("Digita il codice fiscale da 16 cifre del cliente");
            do
            {
                Console.WriteLine("Inserisci il codice fiscale:");
                codfiscale = Console.ReadLine();
            }
            while (codfiscale.Length != 16);

            var PolizzetoUpdate = GetUtenteByCodFiscale(codfiscale);

            if (PolizzetoUpdate != null)
            {
                Console.WriteLine("Scegli la polizza da modificare:");
                ShowPolizza();

                edittipopolizza = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Questo codice fiscale non corrisponde ad un utente");
            }
        }

        private static void UpdateDataScadenza()
        {
            {
                string codfiscale;
                Console.WriteLine("Digita il codice fiscale da 16 cifre del cliente");
                do
                {
                    Console.WriteLine("Inserisci il codice fiscale:");
                    codfiscale = Console.ReadLine();
                }
                while (codfiscale.Length != 16);

                var PolizzetoUpdate = GetUtenteByCodFiscale(codfiscale);

                if (PolizzetoUpdate != null)
                {
                    Console.WriteLine("Scegli la polizza da modificare:");
                    ShowPolizza();

                    DateTime nuovadatascadenza;
                    while(!DateTime.TryParse(Console.ReadLine(), out nuovadatascadenza) || nuovadatascadenza < DateTime.Today )
                    {
                        Console.WriteLine("Data non valida");
                    }
 
                }
                else
                {
                    Console.WriteLine("Questo codice fiscale non corrisponde ad un utente");
                }
            }

        }
    }
}
