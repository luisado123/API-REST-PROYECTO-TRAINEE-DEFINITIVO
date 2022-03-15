using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Library;
using Infraestructure.Entity.Model;

using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }

        IRepository<RolEntity> RolRepository { get; }

        IRepository<RolUserEntity> RolUserRepository { get; }

      

        IRepository<PermissionEntity> PermissionRepository { get; }

        IRepository<TypePermissionEntity> TypePermissionRepository { get; }

        IRepository<RolPermissionEntity> RolesPermissionRepository { get; }

        IRepository<BooksEntity> BooksRepository { get; }

       

    

        IRepository<AutoresEntity> AutoresRepository { get; }

        IRepository<EditorialEntity> EditorialRepository { get; }
        IRepository<Autores_has_librosEntity> Autores_has_librosRepository { get; }












        new void Dispose();

        Task<int> Save();
    }
}