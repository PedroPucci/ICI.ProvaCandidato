using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataBaseContext _context;
        private bool _disposed = false;
        private IUserRepository? _userRepository = null;
        private ITagRepository? _tagRepository = null;
        private INoticeRepository? _noticeRepository = null;

        public RepositoryUoW(DataBaseContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_context);
                }
                return _tagRepository;
            }
        }

        public INoticeRepository NoticeRepository
        {
            get
            {
                if (_noticeRepository == null)
                {
                    _noticeRepository = new NoticeRepository(_context);
                }
                return _noticeRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}