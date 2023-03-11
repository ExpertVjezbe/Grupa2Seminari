using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expert.VedranMarin.Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        [HttpGet("ime/prezime")]
        public ActionResult<string> Unesi(string ime, string prezime)
        {
            var seminar = $"Seminar napravio: {ime} {prezime}";
            return seminar;
        }

        [HttpGet("zbroji/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> Zbroji(int prviBroj, int drugiBroj)
        {
            var zbroj = prviBroj + drugiBroj;
            return zbroj;
        }

        [HttpGet("zbroji2/{prviBroj}/{drugiBroj}")]
        public ActionResult<string> Zbroji2(int prviBroj, int drugiBroj)
        {
            var zbroj2 = prviBroj + drugiBroj;
            {
                return $"Rezultat dva proslijeđena broja je: {zbroj2}";
            }

        }

        [HttpGet("usporedi_brojeve/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> Usporedi(int prviBroj, int drugiBroj)
        {
            if (prviBroj > drugiBroj)
            {
                return prviBroj;
            }
            else
                return drugiBroj;
        }

        [HttpGet("provjeri_brojeve/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> Provjeri(string prviBroj, string drugiBroj)
        {
            int prbroj = System.Convert.ToInt32(prviBroj);
            int drbroj = System.Convert.ToInt32(drugiBroj);

            if (prbroj < drbroj)
            {
                return prbroj + drbroj;
            }
            else if (prbroj == drbroj)
            {
                return prbroj * drbroj;
            }
            else
            {
                return drbroj - prbroj;
            }
        }

        [HttpGet("unesi_broj/{odabraniBroj}")]
        public ActionResult<List<string>> Pomnozi(int odabraniBroj)
        {
            List<string> vratiListu = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var rezultatMnozenja = i * odabraniBroj;
                var vraceniString = $"Rezultat {i} iteracije je {rezultatMnozenja}.";
                vratiListu.Add(vraceniString);
            }
            return vratiListu;
        }
    }
}





