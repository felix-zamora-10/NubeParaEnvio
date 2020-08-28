using Microsoft.Extensions.DependencyInjection;
using NubeParaEnvio.BW.MensajesAzure;
using NubeParaEnvio.BW.MensajesAzure.Contratos;
using NubeParaEnvio.SG.AzureIoT.Conector;

namespace NubeParaEnvio.SI {
    public class InyeccionDeDependencias {

        IServiceCollection services;

        public InyeccionDeDependencias(IServiceCollection services) {
            this.services = services;
        }

        public void InyectaDependencias() {
            services.AddTransient<IConectorDeAzure, ConectorDeAzure>();
            services.AddTransient<IFlujoMensajesAzure, FlujoMensajesAzure>();
        }
    }
}
