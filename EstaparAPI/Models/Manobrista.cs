using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EstaparAPI.Models
{
    public partial class Manobrista
    {
        public Manobrista()
        {
            VeiculoManobra = new HashSet<VeiculoManobra>();
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<VeiculoManobra> VeiculoManobra { get; set; }
    }
}
