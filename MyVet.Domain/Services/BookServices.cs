using Common.Utils.Enums;
using Common.Utils.Exceptions;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Library;
using Infraestructure.Entity.Vet;
using MyLibrary.Domain.Services.Interface;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Autores;
using MyVet.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services
{
   
    public  class BookServices:IBooksServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods

        public List<ConsultaAutoresLibrosDto> GetAllBooks()
        {
            var books = _unitOfWork.Autores_has_librosRepository.FindAll(x => x.Id != null,
                  p => p.AutoresEntity,
                  p=>p.BooksEntity.EditorialEntity,
                  p=>p.BooksEntity
               
                  );
            

            List<ConsultaAutoresLibrosDto> listBooks = books.Select(x => new ConsultaAutoresLibrosDto
            {
                idAutor=x.IdAutor,
             idLibro = x.IdBook,
             idEditorial=x.BooksEntity.EditorialEntity.Id,
                titulo=x.BooksEntity.Titulo,
                sinopsis=x.BooksEntity.Sinopsis,
                editorial=x.BooksEntity.EditorialEntity.Name,
                nameAutor=x.AutoresEntity.Nombre+" "+x.AutoresEntity.Apellidos
                
     


            }).ToList();

            return listBooks;
        }

        public async Task<ResponseDto> DeleteBooksAsync(int idBooks)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(idBooks);
            response.Success = await _unitOfWork.Save() > 0;
            if (response.Success)
                response.Message = "Se elminnó correctamente el libro";
            else
                response.Message = "Hubo un error al eliminar el libro, por favor vuelva a intentalo";

            return response;
        }


        public async Task<bool> InsertBooksAsync(InsertBooksDto data)
        {


            Autores_has_librosEntity autorbook = new Autores_has_librosEntity()
            {
                IdAutor = data.IdAuthor,
                BooksEntity=new BooksEntity()
                {
                    Titulo=data.Titulo,
                    Sinopsis=data.Sinopsis,
                    IdEditorial=data.IdEditorial,
                }
            };
           

            _unitOfWork.Autores_has_librosRepository.Insert(autorbook);
           

            
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBooksAsync(AlterBooksDto data)
        {
            bool result = false;

          Autores_has_librosEntity books = _unitOfWork.Autores_has_librosRepository.FirstOrDefault(x => x.IdBook== data.IdBook,
              p=>p.BooksEntity,
              p=>p.BooksEntity.EditorialEntity);
            if (books != null)
            {
                books.IdAutor = data.IdAutor;
            books.BooksEntity.Titulo=data.Titulo;
                books.BooksEntity.Sinopsis = data.Sinopsis;
                books.BooksEntity.IdEditorial = data.IdEditorial;
                _unitOfWork.Autores_has_librosRepository.Update(books);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }



        #endregion
    }
}
