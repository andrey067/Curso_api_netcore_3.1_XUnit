using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é campo obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email em formato invalido")]
        public string Email { get; set; }
    }
}
