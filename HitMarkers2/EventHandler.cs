using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace HitMarkers2
{
    public class EventHandler
    {
        Config _config = HitMarkers2.Singleton.Config;

        public void HurtingEvent(HurtingEventArgs ev)
        {

            if (ev.Attacker == null || ev.Player == null)
                return;
            if (!ev.IsAllowed || ev.Amount <= 0.01f || ev.Attacker == ev.Player)
                return;

            if (ev.Attacker.Role.Team == Team.SCPs && _config.EnableScpHints == false)
            {
                Log.Debug($"Player {ev.Attacker.Nickname} attacks the player {ev.Player.Nickname}! {Math.Round(ev.Amount).ToString()} damage done");
                return;
            }

            if (!Server.FriendlyFire && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                return;
            }

            string attackerHintBuilder = _config.HintAttackerMessage.Replace("%TargetName%", ev.Player.Nickname).Replace("%TargetRole%", ev.Player.Role.ToString()).Replace("%Damage%", Math.Round(ev.Amount).ToString()).Replace(@"\n", Environment.NewLine);
            string targetHintBuilder = _config.HintTargetMessage.Replace("%AttackerName%", ev.Attacker.Nickname).Replace("%AttackerRole%", ev.Attacker.Role.ToString()).Replace("%Damage%", Math.Round(ev.Amount).ToString()).Replace(@"\n", Environment.NewLine);
            string friendlyFireBuilder = _config.FriendlyFireWarningMessage.Replace("%AttackerName%", ev.Attacker.Nickname).Replace("%AttackerRole%", ev.Attacker.Role.ToString()).Replace("%Damage%", Math.Round(ev.Amount).ToString()).Replace(@"\n", Environment.NewLine).Replace("%DamageHint%", attackerHintBuilder);

            if (_config.EnableAttackerHint)
            {
                ev.Attacker.ShowHint(attackerHintBuilder, _config.HintAttackerDuration);
                Log.Debug($"Player {ev.Attacker.Nickname} attacks the player {ev.Player.Nickname}! {Math.Round(ev.Amount).ToString()} damage done");
            }

            if (_config.EnableTargetHint)
            {
                ev.Player.ShowHint(targetHintBuilder, _config.HintTargetDuration);
            }

            if (_config.EnableFriendlyFireWarning && ev.Attacker.Role.Side == ev.Player.Role.Side)
            {
                ev.Attacker.ShowHint(friendlyFireBuilder, _config.FriendlyFireWarningHintDuration);
                Log.Debug($"Player {ev.Attacker.Nickname} ({ev.Attacker.Role.ToString()}) hits the teammate {ev.Player.Nickname} ({ev.Player.Role.ToString()})! Displaying a warning.");
            }

            if (_config.HitMarkerSize > 1)
                ev.Attacker.ShowHitMarker(_config.HitMarkerSize);
        }
        public void DyingEvent(DyingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null || ev.Attacker == ev.Player)
                return;


            if (_config.EnableKillHint)
            {
                ev.Attacker.ShowHint(_config.KillHintMessage, _config.KillHintDuration);
                Log.Debug($"Player {ev.Attacker.Nickname} ({ev.Attacker.Role.ToString()}) kills the player {ev.Player.Nickname} ({ev.Player.Role.ToString()}!");
            }

        }
    }
}
