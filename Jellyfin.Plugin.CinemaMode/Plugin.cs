using System;
using System.Collections.Generic;
using Jellyfin.Plugin.CinemaMode.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Channels;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.CinemaMode
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "Cinema Mode";

        public override Guid Id => Guid.Parse("653D7940-A42D-4329-9666-432B867466C7");

        public static Plugin Instance { get; private set; }

        public PluginConfiguration PluginConfiguration => Configuration;

        public static IServerApplicationPaths ServerApplicationPaths { get; private set; }

        public static ILibraryManager LibraryManager { get; private set; }
        public static IChannelManager ChannelManager { get; private set; }
        public static ILogger<Plugin> Logger { get; private set; }

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, ILibraryManager libraryManager, IServerApplicationPaths serverApplicationPaths, IChannelManager channelManager, ILogger<Plugin> logger)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            LibraryManager = libraryManager;
            ServerApplicationPaths = serverApplicationPaths;
            ChannelManager = channelManager;
            Logger = logger;
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            yield return new PluginPageInfo
            {
                Name = Name,
                EmbeddedResourcePath = GetType().Namespace + ".Configuration.config.html"
            };
        }
    }
}
