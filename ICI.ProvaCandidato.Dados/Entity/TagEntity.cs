using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class TagEntity : BaseEntity
    {
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "O campo Nome deve ter no máximo 1000 caracteres.")]
        public string Description { get; set; }
    }
}