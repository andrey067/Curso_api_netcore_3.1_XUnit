using Domain.Dtos.Uf;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do Municipio é um campo obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome do munciopio de deve ter no maximo {1} caracteres")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE Inválido")]
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        [Required(ErrorMessage = "UF é um campo obrigatorio")]
        public UfDto Uf { get; set; }
    }
}
