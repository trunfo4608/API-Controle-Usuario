using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Aplication.Dto;
using UsuariosApp.Aplication.Interface;

namespace UsuariosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService? _usuarioAppService;

        public UsuariosController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }
        /// <summary>
        /// Serviço para autentificar o usuário e obter token de acesso
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Autentificar")]
        [ProducesResponseType(typeof(AutenticarResponseDto),200)]
        public IActionResult Autentificar([FromBody] AutenticarRequestDto dto)
        {
            try
            {
                return StatusCode(200, _usuarioAppService.Autentificar(dto));
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500,new { e.Message });
            }

            
        }

        /// <summary>
        /// Serviço de criação de conta do usuário
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("CriarConta")]
        [ProducesResponseType(typeof(CriarContaResponseDto),201)]
        public IActionResult CriarConta([FromBody] CriarContaRequestDto dto)
        {
            try
            {
                return StatusCode(201, _usuarioAppService?.CriarConta(dto));
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {

                return StatusCode(500, new { e.Message });
            }
        }
    }
}
