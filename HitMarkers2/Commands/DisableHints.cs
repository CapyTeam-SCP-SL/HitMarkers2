/// Work In Process
using CommandSystem;
using HitMarkers2.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitMarkers2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class DisableHints : ICommand
    {
        public string Command { get; } = "disableHints";
        public string[] Aliases { get; } = null;
        public string Description { get; } = "Disables hints globally for one round if they are enabled in the config, does nothing if they are already disabled.\nProvide with player ID to disable hints specifically for them for one round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                HintToggleManager.de();
                response = "success, globally disabled!";
                return true;
            }
            else
            {
                try
                {
                    var player = Exiled.API.Features.Player.List.FirstOrDefault(pl => pl.Id == int.Parse(arguments.At(0)));
                    if (player is null)
                    {
                        response = "player does not exist.";
                        return false;
                    }

                    HintToggleManager.de(player.UserId);
                    response = "success, individually disabled!";
                    return true;
                }
                catch (Exception ex)
                {
                    response = $"uh oh, something went horribly wrong. {ex.Message}.";
                    return false;
                }
            }
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class EnableHints : ICommand
    {
        public string Command { get; } = "enableHints";
        public string[] Aliases { get; } = null;
        public string Description { get; } = "Disables hints globally for one round if they are enabled in the config, does nothing if they are already disabled.\nProvide with player ID to disable hints specifically for them for one round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                HintToggleManager.ee();
                response = "success, globally enabled!";
                return true;
            }
            else
            {
                try
                {
                    var player = Exiled.API.Features.Player.List.FirstOrDefault(pl => pl.Id == int.Parse(arguments.At(0)));
                    if (player is null)
                    {
                        response = "player does not exist.";
                        return false;
                    }

                    HintToggleManager.ee(player.UserId);
                    response = "success, individually enabled!";
                    return true;
                }
                catch (Exception ex)
                {
                    response = $"uh oh, something went horribly wrong. {ex.Message}.";
                    return false;
                }
            }
        }
    }
}
