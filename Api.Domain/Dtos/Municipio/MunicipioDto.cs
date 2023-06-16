using Domain.Dtos.Uf;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDto : BaseEntityDto
    {
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public long UfId { get; set; }
        public UfDto UfDto { get; set; }
    }
}
