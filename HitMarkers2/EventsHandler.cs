using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using System;
using HitMarkers2.Features;

namespace HitMarkers2
{
    internal sealed class EventsHandler
    {
        private readonly Config _config;

        public EventsHandler(Config config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.Dying += OnDying;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.Dying -= OnDying;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private void OnWaitingForPlayers()
        {
            HintToggleManager.domagicthing(_config);
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            string DoReplace(string original)
            {
                return original
                    .Replace("%TargetName%", ev.Player.Nickname)
                    .Replace("%TargetRole%", ev.Player.Role.ToString())
                    .Replace("%AttackerName%", ev.Attacker.Nickname)
                    .Replace("%AttackerRole%", ev.Attacker.Role.ToString())
                    .Replace("%Damage%", Math.Round(ev.Amount).ToString())
                    .Replace(@"\n", Environment.NewLine);
            }

            if (!ev.IsAllowed || ev.Amount <= 0.01f ||
                ev.Attacker == null || ev.Player == null ||
                ev.Player == ev.Attacker)
            {
                return;
            }

            var message = DoReplace(_config.AttackerDamagedTarget.Message);

            // For attacker
            if (!Server.FriendlyFire && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                return;
            }
            if (_config.WarningOnFriendlyFire.IsEnabled && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                message = DoReplace(_config.WarningOnFriendlyFire.Message)
                    .Replace("%DamageHint%", message);

                if (!HintToggleManager.ok(ev.Attacker.UserId))
                    goto e;

                ev.Attacker.ShowHint(message, _config.WarningOnFriendlyFire.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" ({ev.Attacker.Role}) hits the teammate \"{ev.Player.Nickname}\" ({ev.Player.Role})! Displaying a warning.");
            }
            else if (_config.AttackerKilledTarget.IsEnabled)
            {
                if (!HintToggleManager.ok(ev.Attacker.UserId))
                    goto e;
                ev.Attacker.ShowHint(message, _config.AttackerDamagedTarget.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" attacks the player \"{ev.Player.Nickname}\"! {Math.Round(ev.Amount)} damage done");
            }

            e:
            // For Target
            if (_config.TargetTookDamage.IsEnabled == true)
            {
                if (!HintToggleManager.ok(ev.Player.UserId))
                    goto FacilitySoundtrack;
                message = DoReplace(_config.TargetTookDamage.Message);
                ev.Player.ShowHint(message, _config.TargetTookDamage.Duration);
            }

            FacilitySoundtrack:
            if (ev.Attacker.IsScp && !_config.IsHitMakerEnabledForScp)
            {
                return;
            }
            if (_config.HitMarkerSize > 1)
            {
                ev.Attacker.ShowHitMarker(_config.HitMarkerSize);
            }
        }

        private void OnDying(DyingEventArgs ev)
        {
            string DoReplace(string original)
            {
                return original
                    .Replace("%TargetName%", ev.Player.Nickname)
                    .Replace("%TargetRole%", ev.Player.Role.ToString())
                    .Replace("%AttackerName%", ev.Attacker.Nickname)
                    .Replace("%AttackerRole%", ev.Attacker.Role.ToString())
                    .Replace(@"\n", Environment.NewLine);
            }

            if (ev.Attacker == null || ev.Player == null ||
                ev.Attacker == ev.Player)
            {
                return;
            }

            if (_config.AttackerKilledTarget.IsEnabled)
            {
                var message = DoReplace(_config.AttackerKilledTarget.Message);

                ev.Attacker.ShowHint(message, _config.AttackerKilledTarget.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" ({ev.Attacker.Role}) kills the player \"{ev.Player.Nickname}\" ({ev.Player.Role}!");
            }
        }
    }
}
