namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticeEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public UserEntity UserModel { get; set; }
    }
}