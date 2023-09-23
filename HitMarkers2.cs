using System;
using Exiled.API.Features;
using Exiled.Loader.Features;

using Player = Exiled.Events.Handlers.Player;

namespace HitMarkers2
{

    public class HitMarkers2 : Plugin<Config>
    {

        private EventHandler EventHandler;
        public static HitMarkers2 Singleton;
        Config _config;

        public override string Name { get; } = "HitMarkers 2";
        public override string Author { get; } = "CapyTeam";
        public override string Prefix { get; } = "HitMarkers2";
        public override Version Version { get; } = new Version(2, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1);


        public override void OnEnabled()
        {
            Singleton = this;
            EventHandler = new EventHandler();
            _config = Config;

            Player.Hurting += EventHandler.HurtingEvent;
            Player.Dying += EventHandler.DyingEvent;

            if(_config.EnableWelcomeMessage)
                ServerConsole.AddLog($"Welcome to {WelcomeMessages.GetMessage()}", ConsoleColor.Green);

            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.HurtingEvent;
            Player.Dying -= EventHandler.DyingEvent;

            EventHandler = null;
            _config = null;
            Singleton = null;

            base.OnDisabled();
        }
    }
}
