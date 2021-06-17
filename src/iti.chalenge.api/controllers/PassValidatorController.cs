using System.Threading.Tasks;
using iti.chalenge.api.domain.models;
using iti.chalenge.api.domain.services.interfaces;
using Microsoft.AspNetCore.Mvc;


namespace iti.chalenge.api.controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class PassValidatorController : ControllerBase
    {
        private IPassValidatorService _service;

        public PassValidatorController(IPassValidatorService service) => this._service = service;

        /// <summary>
        /// Regras detalhadas (abaixo)
        /// </summary>
        /// <remarks>
        /// Regras de Validacao:
        /// 
        /// 1) Apenas caracteres validos: Letras (maiusculas e minusculas), numeros e os seguintes caracteres especiais: !@#$%^*()  
        /// 2) Nove ou mais caracteres 
        /// 3) Ao menos 1 dígito 
        /// 4) Ao menos 1 letra minúscula 
        /// 5) Ao menos 1 letra maiúscula 
        /// 6) Ao menos 1 caractere especial 
        /// 7) Não é permitido repetir caracteres (new)
        ///
        /// Sample request:
        ///
        ///     POST /api/passvalidator/v1/
        ///     {
        ///        "value": "12345aBc!"
        ///     }
        ///
        /// </remarks>
        /// <param name="pass" value="12345aBc!"></param>
        /// <response code="200">value válido</response>

        /// <response code="400"> 
        /// Caso model for nulo. Response:
        ///     {
        ///        message = "Problemas com o request (Json)."
        ///     }
        /// </response>


        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PassModel pass)
        {

            if (string.IsNullOrWhiteSpace(pass.value))
                return BadRequest(new { message = "Problemas com o request (Json)." });

            return Ok(await this._service.IsValid(pass.value));
        }


    }


}