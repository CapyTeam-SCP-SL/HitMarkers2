using Exiled.API.Interfaces;
using HitMarkers2.Features;
using System.ComponentModel;

namespace HitMarkers2
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug logs be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Should Welcome Message be enabled?")]
        public bool IsWelcomeMessageEnabled { get; set; } = true;

        [Description("Are hints globally enabled by default?")]
        public bool AreHintsEnabled { get; set; } = true;

        [Description("Should hitmarkers be displayed to SCPs?")]
        public bool IsHitMakerEnabledForScp { get; set; } = true;

        [Description("Size of custom hitmarker (leave 1 for default)")]
        public float HitMarkerSize { get; set; } = 1f;

        [Description("Hint for attacker when giving damage.")]
        public HintConfigModel AttackerDamagedTargetHint { get; set; } = new HintConfigModel
        {
            IsEnabled = true,
            Message = @"<voffset=17em><size=20>%Damage%</size></voffset>",
            Duration = 0.7F,
        };

        [Description("Hint for the attacker when killing a target.")]
        public HintConfigModel AttackerKilledTargetHint { get; set; } = new HintConfigModel
        {
            IsEnabled = true,
            Message = @"<voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>",
            Duration = 1.0F,
        };

        [Description("Warning hint for the attacker when damaging to teammate.")]
        public HintConfigModel WarningOnFriendlyFireHint = new HintConfigModel
        {
            IsEnabled = true,
            Message = @"%DamageHint%\n<size=34><color=yellow>Warning. Try not to hurt your teammates.</color></size>",
            Duration = 1.0F,
        };

        [Description("Hint for target when taking damage.")]
        public HintConfigModel TargetTakedDamageHint { get; set; } = new HintConfigModel
        {
            IsEnabled = false,
            Message = @"<voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>",
            Duration = 0.7F,
        };
    }
}
