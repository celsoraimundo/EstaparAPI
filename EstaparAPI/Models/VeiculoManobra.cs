using System;
using System.Collections.Generic;

namespace EstaparAPI.Models
{
    public partial class VeiculoManobra
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdManobrista { get; set; }
        public DateTime DataHoraManobra { get; set; }

        public virtual Manobrista IdManobristaNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
