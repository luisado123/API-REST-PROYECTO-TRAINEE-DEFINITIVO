using Infraestructure.Entity.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Autores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
  public interface IAutoresServices
    {
        List<AutoresEntity> GetAllAutores();
        Task<ResponseDto> DeleteAutorAsync(int idAutor);
        Task<bool> InsertAutorAsync(InsertAutoresDto editorial);
        Task<bool> UpdateAutoresAsync(AutoresDto data);
    }
}
