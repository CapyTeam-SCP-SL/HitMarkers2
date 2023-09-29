using System;
using Exiled.API.Features;

namespace HitMarkers2
{
    public sealed class HitMarkers2 : Plugin<Config>
    {
        public static HitMarkers2 Singleton;

        private EventsHandler _eventHandler;

        public override string Name { get; } = "HitMarkers 2";
        public override string Author { get; } = "CapyTeam";
        public override string Prefix { get; } = "HitMarkers2";
        public override Version Version { get; } = new Version(2, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);

        public override void OnEnabled()
        {
            Singleton = this;
            _eventHandler = new EventsHandler(Config);

            _eventHandler.RegisterEvents();

            if (Config.IsWelcomeMessageEnabled)
            {
                var color = Config.Debug
                    ? ConsoleColor.DarkYellow
                    : ConsoleColor.Green;

                ServerConsole.AddLog($"Welcome to {WelcomeMessagesManager.GetWelcomeMessage(Config.Debug)}", color);
            }

            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            _eventHandler?.UnregisterEvents();

            Singleton = null;
            _eventHandler = null;

            base.OnDisabled();
        }
    }
}
