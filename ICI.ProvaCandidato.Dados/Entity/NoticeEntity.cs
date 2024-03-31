using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticeEntity : BaseEntity
    {
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Nome deve ter no máximo 30 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        public UserEntity UserModel { get; set; }
    }
}