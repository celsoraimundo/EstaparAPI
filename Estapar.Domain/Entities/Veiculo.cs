using System;
using System.Collections.Generic;

namespace Estapar.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo()
        {
            VeiculoManobra = new HashSet<VeiculoManobra>();
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<VeiculoManobra> VeiculoManobra { get; set; }
    }
}
