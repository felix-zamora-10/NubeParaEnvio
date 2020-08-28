using System.Threading.Tasks;

namespace NubeParaEnvio.BW.MensajesAzure.Contratos {
    public interface IFlujoMensajesAzure {

        Task<string> EnviaMensajeADispositivoAsync(string mensaje, string dispositivo);

    }
}
