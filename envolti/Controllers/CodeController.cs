using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;


namespace envolti.Controllers
{
    /// <summary>
    /// API para calculos de juros
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly ICodeApplication _codeApplication;
        public CodeController(ICodeApplication codeApplication)
        {
            _codeApplication = codeApplication;
        }

        /// <summary>
        /// Retorna o repositório github com o código fonte
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_codeApplication.ShowCode());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
