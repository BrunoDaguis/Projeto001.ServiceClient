using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project001.ServiceClient.Api.Extensions;
using Project001.ServiceClient.Api.Helpers;
using Project001.ServiceClient.Api.Model;
using Project001.ServiceClient.Domain.Repositories;

namespace Project001.ServiceClient.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Auth([FromServices]IUserRepository repository, [FromServices] IConfiguration configuration, [FromBody]UserAuthModel model)
        {
            try
            {
                var userExists = await repository.GetAsync(model.Email, model.Password);

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });

                var token = JwtAuthHelper.GenerateToken(configuration["KeySecretAuth"], userExists.ToModel());

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}
