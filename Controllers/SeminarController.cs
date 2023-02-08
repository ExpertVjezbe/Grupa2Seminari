using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expert.IvicaHorvat.Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        [HttpGet("zadatak4/vratiimeiprezime/{Ime}/{Prezime}")]
        public ActionResult<string> VratiImeIPrezime(string Ime, string Prezime)

        {
            return "Seminar napisao: " + Ime + " " + Prezime;
        }



        [HttpGet("zadatak5/zbrojidvabroja/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zbrojiDvaBroja(int prviBroj, int drugiBroj)
        {
            return prviBroj + drugiBroj;

        }


        [HttpGet("zadatak6/zbrojiivratistringkaorezultat/{prviBroj}/{drugiBroj}")]
        public ActionResult<string> zbrojiDvaBrojaIVratiString(int prviBroj, int drugiBroj)
        {

            int Zbroj = prviBroj + drugiBroj;
            string Rezultat = Zbroj.ToString();

            return ("Rezultat dva proslijeđena broja je: " + Rezultat);


        }


        [HttpGet("zadatak7/provjeridvabroja/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> provjeriBrojeveIVratiVeci(int prviBroj, int drugiBroj)

        {
            

            if (prviBroj > drugiBroj)

            {
                return (prviBroj);
            }
            else
            {
                return (drugiBroj);
            }
        }

        [HttpGet("zadatak8/konvertirajstringtointiprovjeri/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> provjeriBrojeveKojiJeVeci(string prviBroj, string drugiBroj)
        {
            int A = Convert.ToInt32(prviBroj);
            int B = Convert.ToInt32(drugiBroj);

            if (A < B)
            {
                return (A + B);
            }
            else if (A == B)
            {
                return (A * B);
            }
            else
            {
                return (A - B);
            }
        }

        [HttpGet("zadatak9/pomnoziivrati/{odabraniBroj}")]
        public ActionResult<List<string>> pomnoziVrijednostIVratiString(int odabraniBroj)
        {

            List<string> listaIteracije = new List<string>();
            int rez;
            for (int i = 1; i <= 10; i++)
            {
                string brojac = Convert.ToString(i);
                rez = i * odabraniBroj;
                string zbroj = Convert.ToString(rez);


                listaIteracije.Add("Rezultat " + brojac + "-te iteracije je: " + zbroj);

            }

            {
                return listaIteracije;

            }
        }
    }

}












