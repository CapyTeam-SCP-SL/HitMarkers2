using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using System;
using MEC;
using HitMarkers2.Features;
using System.Collections.Generic;
using Exiled.API.Features.Items;

namespace HitMarkers2
{
    internal sealed class EventsHandler
    {
        private readonly Config _config;
        private readonly Translation _translation;

        public EventsHandler(Config config, Translation translation)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _translation = translation ?? throw new ArgumentNullException(nameof(translation));
        }
        /// <summary>
        /// Registers events when the plugin is enabled
        /// </summary>
        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.Dying += OnDying;
            Exiled.Events.Handlers.Player.ChangedItem += OnChangingItem;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
        }
        /// <summary>
        /// Unregisters events when the plugin is disabled
        /// </summary>
        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.Dying -= OnDying;
            Exiled.Events.Handlers.Player.ChangedItem -= OnChangingItem;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private void OnWaitingForPlayers()
        {
            HintToggleManager.domagicthing(_config);
        }
        /// <summary>
        /// Displays Hint to the attacker and target after receiving damage
        /// </summary>
        /// <param name="ev"></param>
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

            var message = DoReplace(_translation.DamageHint);

            // For attacker
            if (!Server.FriendlyFire && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                return;
            }
            if (_config.WarningOnFriendlyFire.IsEnabled && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                message = DoReplace(_translation.FFWarningHint)
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
                message = DoReplace(_translation.AttackedHint);
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
        /// <summary>
        /// Displays Hint to the attacker after a kill
        /// </summary>
        /// <param name="ev"></param>
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
                var message = DoReplace(_translation.AttakerKillHint);

                ev.Attacker.ShowHint(message, _config.AttackerKilledTarget.Duration);
                Log.Debug($"Player \"{ev.Attacker.Nickname}\" ({ev.Attacker.Role}) kills the player \"{ev.Player.Nickname}\" ({ev.Player.Role}!");
            }
        }
        /// <summary>
        /// Launches a coroutine responsible for updating Ammo Counter when changing an item to a weapon
        /// </summary>
        /// <param name="ev"></param>
        public void OnChangingItem (ChangedItemEventArgs ev)
        {
            if (_config.AmmoCounterSettings.IsEnabled)
            {
                if (ev.Item != null && ev.Item.IsWeapon)
                {
                    Timing.RunCoroutine(AmmoCounterCoroutine(ev.Player));
                }
            }
            else
                return;
        }
        /// <summary>
        /// Updates the ammo counter while the player is holding a weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IEnumerator<float> AmmoCounterCoroutine(Player player)
        {
            while (player.CurrentItem.IsWeapon)
            {
                if (_config.AmmoCounterSettings.IsEnabled)
                {
                    Firearm gun = (Firearm)player.CurrentItem;

                    string DoReplace(string counter_original)
                    {
                        return counter_original
                            .Replace("%player_role_color%", player.Role.Color.ToHex())
                            .Replace("%current_ammo%", gun.Ammo.ToString())
                            .Replace("%max_ammo%", gun.MaxAmmo.ToString())
                            .Replace("%TargetName%", player.Nickname)
                            .Replace("%TargetRole%", player.Role.ToString())
                            .Replace(@"\n", Environment.NewLine);
                    }

                    var counter = DoReplace(_config.AmmoCounterSettings.AmmoCounterDesign);

                    string hint = $"<size={_config.AmmoCounterSettings.AmmoCounterSize}><align={_config.AmmoCounterSettings.AmmoCounterPosLink}><pos={_config.AmmoCounterSettings.AmmoCounterPosX}><voffset={_config.AmmoCounterSettings.AmmoCounterPosY}>{counter}</voffset></pos></align></size>";
                    player.ShowHint(hint, 5);
                    yield return Timing.WaitForSeconds(_config.AmmoCounterSettings.UpdateTime);
                }   
            }
            yield break;
        }
    }
}
