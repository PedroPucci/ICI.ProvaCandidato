﻿using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class UserEntity : BaseEntity
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "O campo Nome deve ter no máximo 30 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "O campo Senha deve ter no máximo 30 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
        public string Mail { get; set; }
    }
}