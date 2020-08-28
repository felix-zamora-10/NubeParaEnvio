using System.Collections.Generic;
using System.Threading.Tasks;
using NubeParaEnvio.BC.MensajesAzure;
using NubeParaEnvio.BW.MensajesAzure.Contratos;

namespace NubeParaEnvio.BW.MensajesAzure {
    public class FlujoMensajesAzure : IFlujoMensajesAzure {

        private readonly IConectorDeAzure conectorDeAzure;
        private readonly ManejadorDeDispositivos manejadorDeDispositivos;

        public FlujoMensajesAzure(IConectorDeAzure conectorDeAzure) {
            this.conectorDeAzure = conectorDeAzure;
            manejadorDeDispositivos = new ManejadorDeDispositivos();
        }

        public async Task<string> EnviaMensajeADispositivoAsync(string mensaje, string dispositivo) {
            string mensajePorRetornar = "";
            List<string> dispositivosFinales;
            Dictionary<string, string> paresDeNombres;

            dispositivosFinales = manejadorDeDispositivos.ObtieneLosDispositivos(dispositivo);
            paresDeNombres = manejadorDeDispositivos.GeneraLosParesDeNombres();
            mensajePorRetornar = await conectorDeAzure.EnviaMensajeADispositivoAsync(mensaje, dispositivosFinales, paresDeNombres);

            return mensajePorRetornar;
        }
    }
}
