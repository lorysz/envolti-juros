using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace envolti.Controllers
{
    /// <summary>
    /// API para controle da taxa de juros
    /// </summary>
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosApplication _jurosApplication;
        public JurosController(IJurosApplication taxaJurosApplication)
        {
            _jurosApplication = taxaJurosApplication;
        }

        /// <summary>
        /// Endpoint para retorno da taxa de juros
        /// </summary>
        /// <returns></returns>
        [Route("taxaJuros")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jurosApplication.GetTaxaJuros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint para realizar o calculo do juros
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("calculajuros")]
        [HttpGet]
        public IActionResult GetJuros([FromQuery] decimal valorinicial, int meses)
        {
            try
            {
                return Ok(_jurosApplication.GetJuros(valorinicial, meses));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
