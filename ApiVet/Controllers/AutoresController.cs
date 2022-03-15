using Common.Utils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Autores;
using MyVet.Domain.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vet.Handlers;

namespace ApiVet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]

    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AutoresController : ControllerBase
    {
        #region Attribute
        private readonly IAutoresServices _autoresServices;
        #endregion

        #region Buider
        public AutoresController(IAutoresServices autoresServices)
        {
            _autoresServices = autoresServices;
        }
        #endregion

        /// <summary>
        /// Obtener todos los Autores
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllAutores")]
        //[CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]

        public IActionResult GetAllAutores()
        {
            
            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = _autoresServices.GetAllAutores(),
                Message = string.Empty
            };

            return Ok(response);

        }

        /// <summary>
        /// Eliminar un autor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteAutor")]
        //[CustomPermissionFilter(Enums.Permission.CancelarPublicacion)]
        public async Task<IActionResult> DeleteAutor(int idAutor)
        {
            IActionResult response;
            ResponseDto result = await _autoresServices.DeleteAutorAsync(idAutor);

            if (result.Success)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }
        /// <summary>
        /// Insertar un nuevo autor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertAutor")]
        //[CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> InsertAutor(InsertAutoresDto autor)
        {
            IActionResult response;

            bool result = await _autoresServices.InsertAutorAsync(autor);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.EditorialInserted : GeneralMessages.EditorialInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Actualizar un autor existente
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateAutor")]
        //[CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> UpdateAutor(AutoresDto data)
        {
            IActionResult response;

            bool result = await _autoresServices.UpdateAutoresAsync(data);
            ResponseDto responseDto = new ResponseDto()
            {
                Success = result,
                Result = result,
                Message = result ? GeneralMessages.AutorInserted : GeneralMessages.AutorInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


    }
}