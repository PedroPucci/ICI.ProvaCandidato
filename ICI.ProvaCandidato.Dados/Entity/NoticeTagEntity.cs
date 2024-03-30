namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticeTagEntity : BaseEntity
    {
        public NoticeEntity NoticeModel { get; set; }
        public TagEntity TagEntity { get; set; }
    }
}