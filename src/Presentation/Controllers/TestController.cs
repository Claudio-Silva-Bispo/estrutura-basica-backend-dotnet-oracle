using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoOdontoPrev.src.Infrastructure.Data.Context;

namespace ProjetoOdontoPrev.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TestController> _logger;

        public TestController(ApplicationContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                var canConnect = _context.Database.CanConnect();
                if (canConnect)
                {
                    return Ok("Conexão com o banco de dados Oracle bem-sucedida!");
                }
                else
                {
                    return StatusCode(500, "Não foi possível conectar ao banco de dados Oracle.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao conectar ao banco de dados Oracle");
                return StatusCode(500, $"Erro ao conectar ao banco de dados Oracle: {ex.Message}");
            }
        }
    }
}
