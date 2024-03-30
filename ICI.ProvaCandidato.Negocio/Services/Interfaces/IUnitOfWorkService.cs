namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        UserService UserService { get; }
        TagService TagService { get; }
        NoticeService NoticeService { get; }
    }
}