using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NubeParaEnvio.BW.MensajesAzure;
using NubeParaEnvio.BW.MensajesAzure.Contratos;

namespace NubeParaEnvio.SI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NubeParaEnvioController : ControllerBase {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("EnviarMensajeDesdeNubeAsync")]
        public async Task<string> EnviarMensajeDesdeNubeAsync([FromServices] IConectorDeAzure conectorDeAzure, [FromQuery] string mensaje, [FromQuery] string dispositivo) {
            string mensajeRetornado;

            FlujoMensajesAzure flujoMensajesAzure = new FlujoMensajesAzure(conectorDeAzure);
            mensajeRetornado = await flujoMensajesAzure.EnviaMensajeADispositivoAsync(mensaje, dispositivo);

            return mensajeRetornado;
        }
    }
}
