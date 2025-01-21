using eCACLoginAPI.Models;
using eCACLoginAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCACLoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly GovBrLoginService _govBrLoginService;
        private readonly CertificateLoginService _certificateLoginService;

        public LoginController()
        {
            _govBrLoginService = new GovBrLoginService();
            _certificateLoginService = new CertificateLoginService();
        }

        [HttpPost("govbr")]
        public async Task<IActionResult> LoginGovBr([FromBody] GovBrLoginRequest request)
        {
            var success = await _govBrLoginService.LoginAsync(request.Username, request.Password);
            if (success)
                return Ok("Login via Gov.br realizado com sucesso!");
            else
                return Unauthorized("Erro ao realizar login via Gov.br.");
        }

        [HttpPost("certificate")]
        public async Task<IActionResult> LoginWithCertificate([FromBody] CertificateLoginRequest request)
        {
            var success = await _certificateLoginService.LoginWithCertificateAsync(request.CertificatePath, request.CertificatePassword);
            if (success)
                return Ok("Login via Certificado Digital A1 realizado com sucesso!");
            else
                return Unauthorized("Erro ao realizar login via Certificado Digital A1.");
        }
    }
}
