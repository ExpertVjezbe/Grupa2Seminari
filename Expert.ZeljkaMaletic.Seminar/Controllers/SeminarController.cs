using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Expert.ZeljkaMaletic.Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase

    //Napravi get Metodu koja prihvaća imePrezime parametar tipa string, i vraća rezultat tipa string i u kojem će pisati "Seminar napravio: {imePrezime}"

    {
        [HttpGet("Seminar napravio/ime/{ime}/prezime/{prezime}")]
        public ActionResult<string> SeminarNapravio(string ime, string prezime)
        {
            string tekst = "Seminar napravio:";
            return tekst + " " + ime + " " + prezime;
        }

    //Napravi Get metodu koja će prihvaćati 2 parametra tipa int, te vratiti zbroj bilo koja 2 broja koji će se proslijediti kroz ta dva parametra

        [HttpGet("zbroj/prviBroj/{prviBroj}/drugiBroj/{drugiBroj}")]
        public ActionResult<int> Zbroj(int prviBroj, int drugiBroj)
        {
            int total;
            total = prviBroj + drugiBroj;
            return total;
        }

        //Napravi Get metodu koja će primiti dva parametra tipa int , zbrojiti ta dva broja i vratiti rezultat tipa string u kojem će pisati "Rezultat dva proslijeđena broja je: {rezultat}"}"

        [HttpGet("Rezultat dva proslijeđena broja je/prviBroj/{prviBroj}/drugiBroj/{drugiBroj}")]
        public ActionResult<string> Rezultat(int prviBroj, int drugiBroj)
        {
            Console.Write("Rezultat dva proslijeđena broja je: ");
            int rezultat;
            rezultat = prviBroj + drugiBroj;

            string tekst = "Rezultat dva proslijeđena broja je:";
            return tekst + rezultat.ToString ();


        }


        //Napravi get metodu koja će primiti 2 broja tipa string. Konvertiraj ih u integer i napravi sljedeće provjere:
	//- ako je prvi broj manji od drugoga - zbroji ta ta dva broja i vrati rezultat
	//- ako je prvi broj jednak drugom - pomnoži ta dva broja i vrati rezultat
	//- u suprotnom oduzmi drugi broj od prvog i vrati rezultat

        [HttpGet("Dva broja tipa string s provjerama/prviBroj/{prviBroj}/drugiBroj/{drugiBroj}")]
        public ActionResult<int> Rezultat(string prviBroj, string drugiBroj)
        {
            int prvibr = Convert.ToInt32(prviBroj);
            int drugibr = Convert.ToInt32(drugiBroj);
            
            var retVal = 0;

            if (prvibr < drugibr)
            {
                retVal = prvibr + drugibr;
            }
            else if (prvibr == drugibr)
            {
                retVal = prvibr * drugibr;
            }
            else
            {
                retVal = drugibr - prvibr;
            }
            return retVal;
        }

        //Napravi Get metodu koja prima  parametar {odabraniBroj} tipa int.
        //- u svakoj iteraciji petlje pomnozi {i} vrijednost petlje sa prosliijeđenom vrijednosti odabraniBroj(i* odabraniBroj)
        //- vrati listu stringova sa 10 rezultata na način da String izgleda ovako "rezultat {i}. iteracije je {rezultatMnozenja}"

        [HttpGet("{Broj}")]
        public ActionResult<List<string>> Broj(int Broj)
        {
            List<string> list = new List<string>();

            //definiranje - uslov - korak
            for (int i = 1; i <= 10; i++)
            {

                int rez = i * Broj;

                string rezultat = Convert.ToString(rez);

                string itr = Convert.ToString(i);

                list.Add($"rezultat iteracije" + " " + itr + " " + "je" + " " + rezultat);
            }

            return list;


        }



    }
}
