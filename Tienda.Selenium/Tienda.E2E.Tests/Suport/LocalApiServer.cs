using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Tienda.E2E.Tests.Suport
{
    /// <summary>
    /// La clase LocalApiServer es una utilidad que permite iniciar un servidor API local para pruebas de extremo a extremo (E2E)
    /// </summary>
    public sealed class LocalApiServer : IAsyncDisposable
    {

        private readonly WebApplication _app; // Instancia de la aplicación web propia
        public string Url { get; }

        private LocalApiServer(WebApplication app, string url)
        {
            _app = app;
            Url = url;
        }

        /// <summary>
        /// Inicia un servidor API local utilizando la clase ApiHost para crear una instancia de WebApplication.
        /// Configura el servidor para escuchar en una dirección IP local y un puerto dinámico, 
        /// lo que permite evitar conflictos con otros servicios que puedan estar utilizando puertos específicos.
        /// </summary>
        /// <returns>Una instancia de LocalApiServer que representa el servidor API local iniciado.</returns>
        public static async Task<LocalApiServer> StartAsync()
        {
            int port = GetFreePort();
            string url = $"http://127.0.0.1:{port}";
            WebApplication app = ApiHost.Create(["--urls", url]);
            await app.StartAsync();
            return new LocalApiServer(app, url);
        }

        /// <summary>
        /// Detiene el servidor API local y libera los recursos asociados.
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await _app.StopAsync();
            await _app.DisposeAsync();
        }


        /// <summary>
        /// Obtiene un puerto libre en el sistema para iniciar el servidor API local. 
        /// Esto es útil para evitar conflictos con otros servicios que puedan estar utilizando puertos específicos.
        /// </summary>
        /// <returns>Un puerto libre disponible en el sistema.</returns>
        private static int GetFreePort()
        {
            TcpListener listener = new(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }


    }
}
