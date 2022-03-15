using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Library;
using Infraestructure.Entity.Model;

using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Vet;
using System;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Attributes

        private readonly DataContext _context;
        private bool disposed = false;

        #endregion Attributes

        #region builder

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        #endregion builder

        #region Properties
        private IRepository<UserEntity> userRepository;
        private IRepository<RolEntity> rolRepository;
        private IRepository<RolUserEntity> rolUserRepository;
     
        private IRepository<PermissionEntity> permissionRepository;
        private IRepository<TypePermissionEntity> typePermissionRepository;
        private IRepository<RolPermissionEntity> rolPermissionRepository;

        private IRepository<BooksEntity> booksRepository;
        private IRepository<AutoresEntity> autoresRepository;
        private IRepository<EditorialEntity> editorialRepository;
        private IRepository<Autores_has_librosEntity> autores_has_librosRepository;

        #endregion


        #region Members
        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<UserEntity>(_context);

                return userRepository;
            }
        }

        public IRepository<RolEntity> RolRepository
        {
            get
            {
                if (this.rolRepository == null)
                    this.rolRepository = new Repository<RolEntity>(_context);

                return rolRepository;
            }
        }

        public IRepository<RolUserEntity> RolUserRepository
        {
            get
            {
                if (this.rolUserRepository == null)
                    this.rolUserRepository = new Repository<RolUserEntity>(_context);

                return rolUserRepository;
            }
        }

       

    

        public IRepository<PermissionEntity> PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                    this.permissionRepository = new Repository<PermissionEntity>(_context);

                return permissionRepository;
            }
        }

        public IRepository<TypePermissionEntity> TypePermissionRepository
        {
            get
            {
                if (this.typePermissionRepository == null)
                    this.typePermissionRepository = new Repository<TypePermissionEntity>(_context);

                return typePermissionRepository;
            }
        }

        public IRepository<RolPermissionEntity> RolesPermissionRepository
        {
            get
            {
                if (this.rolPermissionRepository == null)
                    this.rolPermissionRepository = new Repository<RolPermissionEntity>(_context);

                return rolPermissionRepository;
            }
        }

        public IRepository<BooksEntity> BooksRepository
        {
            get
            {
                if (this.booksRepository == null)
                    this.booksRepository = new Repository<BooksEntity>(_context);

                return booksRepository;
            }
        }

     

      

      

        public IRepository<AutoresEntity> AutoresRepository
        {
            get
            {
                if (this.autoresRepository == null)
                    this.autoresRepository = new Repository<AutoresEntity>(_context);

                return autoresRepository;
            }
        }

        public IRepository<EditorialEntity> EditorialRepository
        {
            get
            {
                if (this.editorialRepository == null)
                    this.editorialRepository = new Repository<EditorialEntity>(_context);

                return editorialRepository;
            }
        }

        public IRepository<Autores_has_librosEntity> Autores_has_librosRepository
        {
            get
            {
                if (this.autores_has_librosRepository == null)
                    this.autores_has_librosRepository = new Repository<Autores_has_librosEntity>(_context);

                return autores_has_librosRepository;
            }
        }


        #endregion


        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}