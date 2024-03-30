namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticeModel : BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public UserModel UserModel { get; set; }
    }
}