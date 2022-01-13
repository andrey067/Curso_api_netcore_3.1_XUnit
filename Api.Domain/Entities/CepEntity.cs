using Api.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public IEquatable<CepEntity> Ceps { get; set; }
    }
}
