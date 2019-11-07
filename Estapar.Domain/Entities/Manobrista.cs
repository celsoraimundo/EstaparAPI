using System;
using System.Collections.Generic;

namespace Estapar.Domain.Entities
{
    public class Manobrista : BaseEntity
    {
        public Manobrista()
        {
            VeiculoManobra = new HashSet<VeiculoManobra>();
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<VeiculoManobra> VeiculoManobra { get; set; }
    }
}