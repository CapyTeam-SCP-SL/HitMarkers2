using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using System;

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
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.Dying -= OnDying;
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

            var message = DoReplace(_config.AttackerDamagedTargetHint.Message);

            // For attacker
            if (_config.WarningOnFriendlyFireHint.IsEnabled && ev.DamageHandler.IsFriendlyFire)
            {
                message = DoReplace(_config.WarningOnFriendlyFireHint.Message)
                    .Replace("%DamageHint%", message);

                ev.Attacker.ShowHint(message, _config.WarningOnFriendlyFireHint.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" ({ev.Attacker.Role}) hits the teammate \"{ev.Player.Nickname}\" ({ev.Player.Role})! Displaying a warning.");
            }
            else if (_config.AttackerKilledTargetHint.IsEnabled)
            {
                ev.Attacker.ShowHint(message, _config.AttackerDamagedTargetHint.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" attacks the player \"{ev.Player.Nickname}\"! {Math.Round(ev.Amount)} damage done");
            }

            // For Target
            if (_config.TargetTakedDamageHint?.IsEnabled ?? false)
            {
                message = DoReplace(_config.TargetTakedDamageHint.Message);
                ev.Player.ShowHint(message, _config.TargetTakedDamageHint.Duration);
            }

            if (!(ev.Attacker.IsScp && _config.IsHitMakerEnabledForScp) && _config.HitMarkerSize > 1)
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

            if (_config.AttackerKilledTargetHint.IsEnabled)
            {
                var message = DoReplace(_config.AttackerKilledTargetHint.Message);

                ev.Attacker.ShowHint(message, _config.AttackerKilledTargetHint.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" ({ev.Attacker.Role}) kills the player \"{ev.Player.Nickname}\" ({ev.Player.Role}!");
            }
        }
    }
}
