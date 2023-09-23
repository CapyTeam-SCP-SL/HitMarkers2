using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using UnityEngine;


namespace HitMarkers2.Commands
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class DisableHints : ParentCommand
    {
        public DisableHints() => LoadGeneratedCommands();
        public string Command => "disablehints";
        public override string[] Aliases { get; } = new string[] { "dis", "disablehi" };
        public string Description => "Disables or enables HitMarkers.";
        public override void LoadGeneratedCommands() { }

        public override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!((CommandSender)sender).CheckPermission("ev.run"))
            {
                response = "<color=red>You do not have permission to use this command!</color>";
                return false;
            }
            if (arguments.Count < 1)
            {
                response = "Usage: disablehints ((hint name/id) or (all / *))" + "\disablehints hintlist";
                return false;
            }
            switch (arguments.At(0))
            {
                case "*":
                case "all":
                    if (arguments.Count < 1)
                    {
                        response = "Usage: disablehints ((hint name/id) or (all / *))";
                        return false;
                    }
                    if (!Enum.TryParse(arguments.At(1), true, out ItemType item))
                    {
                        response = $"Invalid : hint name/id{arguments.At(1)}";
                        return false;
                    }
            }
        }
    }
}
