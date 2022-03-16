using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using Vet.Handlers;

namespace ApiVet.Controllers
{

    [Authorize]
    [Route("api/[controller]")]

    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UsuariosController : ControllerBase
    {
        #region Attribute
        private readonly IUserServices _usersServices;
        #endregion

        #region Buider
        public UsuariosController(IUserServices usersServices)
        {
            _usersServices = usersServices;
        }
        #endregion

        /// <summary>
        /// Obtener todos los Usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllUsuarios")]
        //[CustomPermissionFilter(Enums.Permission.ConsultarPublicacion)]

        public IActionResult GetAllBooks()
        {

            ResponseDto response = new ResponseDto()
            {
                Success = true,
                Result = _usersServices.GetAll(),
                Message = string.Empty
            };

            return Ok(response);

        }
    }

}