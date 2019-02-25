using System;
using System.Collections.Generic;
using MediaBrowser.Model.Events;
using ServiceStack;

namespace MediaBrowser.Controller.Net
{
    /// <summary>
    /// Interface IHttpServer
    /// </summary>
    public interface IHttpServer : IDisposable
    {
        /// <summary>
        /// Gets the URL prefix.
        /// </summary>
        /// <value>The URL prefix.</value>
        string[] UrlPrefixes { get; }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();

        /// <summary>
        /// Occurs when [web socket connected].
        /// </summary>
        event EventHandler<GenericEventArgs<IWebSocketConnection>> WebSocketConnected;

        /// <summary>
        /// If set, all requests will respond with this message
        /// </summary>
        string GlobalResponse { get; set; }
    }
}
