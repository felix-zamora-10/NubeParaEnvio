using System.Collections.Generic;
using System.Threading.Tasks;

namespace NubeParaEnvio.BW.MensajesAzure.Contratos {
    public interface IConectorDeAzure {
        Task<string> EnviaMensajeADispositivoAsync(string mensaje, List<string> dispositivos, Dictionary<string, string> paresDeNombres);

    }
}
