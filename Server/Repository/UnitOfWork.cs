//using StreamSpoatsPR.Server.Data;
//using StreamSpoatsPR.Server.IRepository;
//using StreamSpoatsPR.Shared.Domain;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using StreamSpoatsPR.Server.Model;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Type = StreamSpoatsPR.Shared.Domain.Type;

//namespace StreamSpoatsPR.Server.Repository
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly ApplicationDbContext _context;
//        private IGenericRepository<Brand> _brands;
//        private IGenericRepository<Shared.Domain.Type> _types;
//        private IGenericRepository<Sport> _sports;
//        private IGenericRepository<Prodname> _prodnames;
//        private IGenericRepository<Serial> _serials;
//        private IGenericRepository<Review> _reviews;

//        private UserManager<ApplicationUser> _userManager;

//        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        public IGenericRepository<Brand> Brands
//            => _brands ??= new GenericRepository<Brand>(_context);
//        public IGenericRepository<Shared.Domain.Type> Types
//            => _types ??= new GenericRepository<Shared.Domain.Type>(_context);
//        public IGenericRepository<Sport> Sports
//            => _sports ??= new GenericRepository<Sport>(_context);
//        public IGenericRepository<Prodname> Prodnames
//            => _prodnames ??= new GenericRepository<Prodname>(_context);
//        public IGenericRepository<Serial> Serials
//            => _serials ??= new GenericRepository<Serial>(_context);
//        public IGenericRepository<Review> Reviews
//            => _reviews ??= new GenericRepository<Review>(_context);

//        IGenericRepository<Shared.Type> IUnitOfWork.Types => throw new NotImplementedException();

//        IGenericRepository<Brand> IUnitOfWork.Brands => throw new NotImplementedException();

//        IGenericRepository<Sport> IUnitOfWork.Sports => throw new NotImplementedException();

//        IGenericRepository<Prodname> IUnitOfWork.Prodnames => throw new NotImplementedException();

//        IGenericRepository<Serial> IUnitOfWork.Serials => throw new NotImplementedException();

//        IGenericRepository<Review> IUnitOfWork.Reviews => throw new NotImplementedException();

//        public void Dispose()
//        {
//            _context.Dispose();
//            GC.SuppressFinalize(this);
//        }

//        public async Task Save(HttpContext httpContext)
//        {
//            //To be implemented
//            string user = "System";

//            var entries = _context.ChangeTracker.Entries()
//                .Where(q => q.State == EntityState.Modified ||
//                    q.State == EntityState.Added);

          
//        }

//        void IDisposable.Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        Task IUnitOfWork.Save(HttpContext httpContext)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}