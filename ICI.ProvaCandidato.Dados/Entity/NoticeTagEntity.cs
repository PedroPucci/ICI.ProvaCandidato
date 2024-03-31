using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticeTagEntity : BaseEntity
    {
        [Required(ErrorMessage = "A noticia é obrigatoria.")]
        public NoticeEntity NoticeModel { get; set; }

        [Required(ErrorMessage = "O campo Tag é obrigatório.")]
        public TagEntity TagEntity { get; set; }
    }
}