using BE_U1_W2_D3.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_U1_W2_D3.Controllers
{
    public class BigliettiController : Controller
    {
        private static List<Biglietto> biglietti = new List<Biglietto>();
        public static List<Sala> sale = new List<Sala>
        {
            new Sala() {Id=Guid.NewGuid(), Nome = "SALA NORD"},
            new Sala() {Id=Guid.NewGuid(), Nome = "SALA EST"},
            new Sala() {Id=Guid.NewGuid(), Nome = "SALA SUD"}
        };

        public IActionResult Index()
        {
            var viewModel = new Biglietto();

            ViewBag.Sale = sale;
            ViewBag.Biglietti = biglietti;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Acquista(Biglietto biglietto)
        {
            var sala = sale.FirstOrDefault(s => s.Id == biglietto.Sala?.Id);

            if (sala != null && sala.PostiTotali > 0)
            {
                sala.PostiTotali--;

                if (!biglietto.isRidotto)
                {
                    sala.BigliettiVenduti++;
                }
                else
                {
                    sala.BigliettiRidotti++;
                }

                biglietti.Add(new Biglietto
                {
                    Id = Guid.NewGuid(),
                    Nome = biglietto.Nome,
                    Cognome = biglietto.Cognome,
                    Sala = sala,
                    isRidotto = biglietto.isRidotto
                });
            }

            return RedirectToAction("Index");
        }
    }
}
