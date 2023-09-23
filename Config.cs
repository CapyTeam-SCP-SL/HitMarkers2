using Exiled.API.Interfaces;
using System.ComponentModel;

namespace HitMarkers2
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug logs be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Should Welcome Message be enabled?")]
        public bool EnableWelcomeMessage { get; set; } = true;

        [Description("Should a hint be displayed to the attacker?")]
        public bool EnableAttackerHint { get; set; } = true;

        [Description("Hint message for attacker")]
        public string HintAttackerMessage { get; set; } = @"<voffset=17em><size=20>%Damage%</size></voffset>";

        [Description("Hint duration for attacker")]
        public float HintAttackerDuration { get; set; } = 0.7f;

        [Description("Should a hint be displayed to the target?")]
        public bool EnableTargetHint { get; set; } = false;

        [Description("Hint message for target")]
        public string HintTargetMessage { get; set; } = @"<voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>";

        [Description("Hint duration for target")]
        public float HintTargetDuration { get; set; } = 0.7f;

        [Description("Should a hint be displayed to the attacker when they kill a player?")]
        public bool EnableKillHint { get; set; } = true;

        [Description("Hint message for kill")]
        public string KillHintMessage { get; set; } = @"<voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>";

        [Description("Hint duration for kill message")]
        public float KillHintDuration { get; set; } = 1f;

        [Description("Should hitmarkers be displayed to SCPs?")]
        public bool EnableScpHints { get; set; } = true;
        [Description("Should Friendly Fire Warning be displayed?")]
        public bool EnableFriendlyFireWarning { get; set; } = true;

        [Description("Hint message for Friendly Fire Warning")]
        public string FriendlyFireWarningMessage { get; set; } = @"%DamageHint%\n<size=34><color=yellow>Warning. Try not to hurt your teammates.</color></size>";
        
        [Description("Hint duration for Friendly Fire Warning message")]
        public float FriendlyFireWarningHintDuration { get; set; } = 1f;

        [Description("Size of custom hitmarker (leave 1 for default)")]
        public float HitMarkerSize { get; set; } = 1f;
    }
}
