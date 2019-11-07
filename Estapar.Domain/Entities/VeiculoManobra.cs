using System;
using System.Collections.Generic;

namespace Estapar.Domain.Entities
{
    public class VeiculoManobra : BaseEntity
    {
        public int IdVeiculo { get; set; }
        public int IdManobrista { get; set; }
        public DateTime DataHoraManobra { get; set; }

        public virtual Manobrista IdManobristaNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
