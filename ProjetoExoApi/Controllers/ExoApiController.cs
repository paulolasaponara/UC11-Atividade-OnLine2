using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoExoApi.Interfaces;
using ProjetoExoApi.Models;
using ProjetoExoApi.Repositories;

namespace ProjetoExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExoApiController : ControllerBase
    {
        private readonly IExoApiRepository _iExoApiRepository;
        public ExoApiController(IExoApiRepository iExoApiRepository)
        {
            _iExoApiRepository = iExoApiRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iExoApiRepository.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                ExoApi exoApi = _iExoApiRepository.BuscarPorId(id);
                if (exoApi == null)
                {
                    return NotFound();
                }
                return Ok(exoApi);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        
        public IActionResult Cadastrar(ExoApi exoApi)
        {
            try
            {
                _iExoApiRepository.Cadastrar(exoApi);
                return Ok(exoApi);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPut]

        public IActionResult Update(int id, ExoApi exoApi)
        {
            try
            {
                _iExoApiRepository.Atualizar(id, exoApi);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _iExoApiRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
