using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Autores;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class AutoresServices : IAutoresServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutoresServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<AutoresEntity> GetAllAutores() => _unitOfWork.AutoresRepository.GetAll().ToList();

        public async Task<ResponseDto> DeleteAutorAsync(int idAutor)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.AutoresRepository.Delete(idAutor);
            response.Success = await _unitOfWork.Save() > 0;
            if (response.Success)
                response.Message = "Se elminnó correctamente el Autor";
            else
                response.Message = "Hubo un error al eliminar el Autor, por favor vuelva a intentalo";

            return response;
        }
        public async Task<bool> InsertAutorAsync(InsertAutoresDto data)
        {


            AutoresEntity autores = new AutoresEntity();
            {
               autores.Apellidos = data.Apellidos;
                autores.Nombre = data.Nombres;
            }
            _unitOfWork.AutoresRepository.Insert(autores);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateAutoresAsync(AutoresDto data)
        {
            bool result = false;

            AutoresEntity autor = _unitOfWork.AutoresRepository.FirstOrDefault(x => x.IdAutor == data.Id);
            if (autor != null)
            {
                autor.Nombre = data.Nombres;
                autor.Apellidos = data.Apellidos;

                _unitOfWork.AutoresRepository.Update(autor);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

    }
}
