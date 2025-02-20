using System.ComponentModel.DataAnnotations;

namespace BE_U1_W2_D3.Models
{
    public class BigliettoViewModel
    {
        public List<Biglietto> Biglietti { get; set; } = new List<Biglietto>();
        public List<Sala> Sale { get; set; } = new List<Sala>();
    }
}
