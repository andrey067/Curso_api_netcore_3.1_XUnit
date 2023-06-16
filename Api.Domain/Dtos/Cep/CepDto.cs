using Domain.Dtos.Municipio;
using System;

namespace Domain.Dtos.Cep
{
    public class CepDto : BaseEntityDto
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public long MunicipioId { get; set; }

        public MunicipioDto Municipio { get; set; }
    }
}
