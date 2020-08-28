using System.Threading.Tasks;
using NubeParaEnvio.BW.MensajesAzure.Contratos;
using Microsoft.Azure.Devices;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace NubeParaEnvio.SG.AzureIoT.Conector {
    public class ConectorDeAzure : IConectorDeAzure {

        private readonly string conexionDeDispositivo = "HostName=IoTHubTestLc.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=3dJ6+zkw6yWjaTOI5VVK4r5xO4lawtzOs0AGM71kb8M=";

        public async Task<string> EnviaMensajeADispositivoAsync(string mensaje, List<string> dispositivos, Dictionary<string, string> paresDeNombres) {
            string mensajelocal = "";
            string mensajePorRetornar = "";

            for (int dispositivo = 0; dispositivo < dispositivos.Count; dispositivo++) {
                mensajelocal = string.Format("{0} > Enviando mensaje '{1}' al dispositivo '{2}'.\n", DateTime.Now.ToLocalTime(),
                    mensaje, ObtieneNombreDeDispositivo(dispositivos[dispositivo], paresDeNombres));

                using (var clienteDelServicio = ServiceClient.CreateFromConnectionString(conexionDeDispositivo)) {
                    await EjecutaEnviarMensajeADispositivoAsync(mensaje, dispositivos[dispositivo], clienteDelServicio).ConfigureAwait(false);
                }

                mensajePorRetornar = string.Concat(mensajePorRetornar, mensajelocal);
            }

            return mensajePorRetornar;
        }

        private string ObtieneNombreDeDispositivo(string dispositivo, Dictionary<string, string> paresDeNombres) {
            string nombreDelDispositivo = "";

            nombreDelDispositivo = paresDeNombres.FirstOrDefault(elemento => elemento.Key == dispositivo).Value;

            return nombreDelDispositivo;
        }

        private async Task EjecutaEnviarMensajeADispositivoAsync(string mensaje, string dispositivo, ServiceClient clienteDelServicio) {
            Message mensajePorEnviar = new Message(Encoding.ASCII.GetBytes(mensaje));
                await clienteDelServicio.SendAsync(dispositivo, mensajePorEnviar);
        }
    }
}
