using System.Collections.Generic;
using System.Reflection;
using Emby.Server.Implementations;
using Emby.Server.Implementations.HttpServer;
using Jellyfin.Server.SocketSharp;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Server
{
    public class CoreAppHost : ApplicationHost
    {
        public CoreAppHost(
            ServerApplicationPaths applicationPaths,
            ILoggerFactory loggerFactory,
            StartupOptions options,
            IFileSystem fileSystem,
            IEnvironmentInfo environmentInfo,
            MediaBrowser.Controller.Drawing.IImageEncoder imageEncoder,
            MediaBrowser.Common.Net.INetworkManager networkManager,
            IConfiguration configuration)
            : base(
                applicationPaths,
                loggerFactory,
                options,
                fileSystem,
                environmentInfo,
                imageEncoder,
                networkManager,
                configuration)
        {
        }

        public override bool CanSelfRestart => StartupOptions.RestartPath != null;

        protected override bool SupportsDualModeSockets => true;

        protected override void RestartInternal() => Program.Restart();

        protected override IEnumerable<Assembly> GetAssembliesWithPartsInternal()
        {
            yield return typeof(CoreAppHost).Assembly;
        }

        protected override void ShutdownInternal() => Program.Shutdown();

        protected override IHttpListener CreateHttpListener()
            => new WebSocketSharpListener(Logger);
    }
}
