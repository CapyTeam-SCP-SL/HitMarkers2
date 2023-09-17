using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Diagnostics;

namespace HitMarkers2
{
    public class EventHandler
    {
        Config _config = HitMarkers.Singleton.Config;

        public void HurtingEvent(HurtingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null)
                return;
            if (!ev.IsAllowed || ev.Amount < 0 || ev.Attacker == ev.Player)
                return;

            if (ev.Attacker.Role.Team == Team.SCPs && _config.EnableScpHints == false)
                return;

            string attackerHintBuilder = _config.HintAttackerMessage.Replace("%TargetName%", ev.Player.Nickname).Replace("%TargetRole%", ev.Player.Role.ToString()).Replace("%Damage%", Math.Round(ev.Amount).ToString()).Replace(@"\n", Environment.NewLine);
            string targetHintBuilder = _config.HintTargetMessage.Replace("%AttackerName%", ev.Attacker.Nickname).Replace("%AttackerRole%", ev.Attacker.Role.ToString()).Replace("%Damage%", Math.Round(ev.Amount).ToString()).Replace(@"\n", Environment.NewLine);
            

            if (_config.EnableAttackerHint)
                ev.Attacker.ShowHint(attackerHintBuilder, _config.HintAttackerDuration);

            if (_config.EnableTargetHint)
                ev.Player.ShowHint(targetHintBuilder, _config.HintTargetDuration);

            if (_config.HitMarkerSize > 1)
                ev.Attacker.ShowHitMarker(_config.HitMarkerSize);
        }

        public void DyingEvent(DyingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null || ev.Attacker == ev.Player)
                return;


            if (_config.EnableKillHint)
                ev.Attacker.ShowHint(_config.KillHintMessage, _config.KillHintDuration);
        }
    }
}
