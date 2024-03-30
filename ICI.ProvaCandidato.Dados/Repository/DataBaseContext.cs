using ICI.ProvaCandidato.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICI.ProvaCandidato.Dados
{
    public class DataBaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataBaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql("WebApiDatabase");
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            }
        }


        public DbSet<UserEntity> UserModel { get; set; }
        public DbSet<TagEntity> TagEntity { get; set; }
        public DbSet<NoticeEntity> NoticeEntity { get; set; }
        public DbSet<NoticeTagEntity> NoticeTagEntity { get; set; }
    }
}