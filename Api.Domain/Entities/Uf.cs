using Api.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Uf : BaseEntity
    {

        [Required]
        [MaxLength(2)]
        public string Sigla { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; private set; }

        public IEnumerable<Municipio> Municipios { get; private set; } = new List<Municipio>();

        public Uf(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }
    }
}
