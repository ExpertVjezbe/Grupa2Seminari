using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Expert.MilanJurjevic.Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        [HttpGet("Ime/{Ime}/Prezime/{Prezime}")]
        public ActionResult<string> VratiIme(string Ime, string Prezime)
        {
            string Name = Ime;
            string Surname = Prezime;
            string Opis = "Saminar napravio: ";
            return (Opis + Ime + " " + Prezime);

        }

        [HttpGet("prvibroj/{prviBroj}/drugibroj/{drugiBroj}")]

        public ActionResult<int> Zbroji(int prviBroj, int drugiBroj)
        {
            int prvi = prviBroj;
            int drugi = drugiBroj;
            int zbroj = prvi + drugi;
            return (zbroj);


        }

        [HttpGet("prvibr/{prviB}/drugiB/{drugiB}")]

       public ActionResult<string> Zbroji1(int prviB, int drugiB)
        {
            int prvi = prviB;
            int drugi = drugiB;
            int zbroj = prviB + drugiB;
            string Zbroj = Convert.ToString(zbroj);
            return ("Rezutlat dva prosljeđena broja je " + Zbroj);

        }

        [HttpGet("prvibr/{prviB}/drugibr/{drugiB}")]
        public ActionResult<int> Vrati1(int prviB, int drugiB)
        {
            int prvi = prviB;
            int drugi = drugiB;

            if (prvi > drugi)
            {
                return (prvi);
            }
            else
            {
                return (drugi);
            }
        }

        [HttpGet("prvi/{prviBroj}/drugi/{drugiBroj}")]

        public ActionResult<int> Vrati(string prviBroj, string drugiBroj)
        {
            int prvi = Convert.ToInt32(prviBroj);
            int drugi = Convert.ToInt32(drugiBroj);

            if (prvi < drugi)

            {
                return (prvi + drugi);

            } else if (prvi == drugi)
            {
                return (prvi * drugi);
            } else
            {
                return (prvi - drugi);

            }

        }

        [HttpGet("prvi/{prviBroj}")]
        public ActionResult<List<string>> Vrati3(int prviBroj)
        {
            List<string> zapetljanaLista = new List<string>();
            int rez;
            for (int i = 1; i <= prviBroj; i++)
            { string brojac = Convert.ToString(i);
                rez = i * prviBroj;
                string zbroj = Convert.ToString(rez);
                zapetljanaLista.Add("rezultat " + brojac+ "-te iteracije je: " + zbroj);
             
            }
            return zapetljanaLista;


        }
    }
}
