//using StreamSpoatsPR.Shared.Domain;
//using Microsoft.AspNetCore.Http;
//using StreamSpoatsPR.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace StreamSpoatsPR.Server.IRepository
//{
//    public interface IUnitOfWork : IDisposable
//    {
//        Task Save(HttpContext httpContext);
//        IGenericRepository<Brand> Brands { get; }
//        IGenericRepository<StreamSpoatsPR.Shared.Type> Types { get; }
//        IGenericRepository<Sport> Sports { get; }
//        IGenericRepository<Prodname> Prodnames { get; }
//        IGenericRepository<Serial> Serials { get; }
//        IGenericRepository<Review> Reviews { get; }
//    }
//}