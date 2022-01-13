using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "Cep é campo obrigatorio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é um campo obrigatorio")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Municiopio é um campo obrigatorio")]
        public Guid MunicipioId { get; set; }
    }
}
