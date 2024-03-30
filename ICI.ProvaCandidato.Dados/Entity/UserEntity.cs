namespace ICI.ProvaCandidato.Web.Models
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}