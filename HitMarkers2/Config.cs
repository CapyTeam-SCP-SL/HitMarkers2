using Exiled.API.Interfaces;
using HitMarkers2.Features;
using System.Collections.Generic;
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
        public HintConfigModel AttackerDamagedTarget { get; set; } = new HintConfigModel
        {
            IsEnabled = true,
            Duration = 0.7F,
        };

        [Description("Hint for the attacker when killing a target.")]
        public HintConfigModel AttackerKilledTarget { get; set; } = new HintConfigModel
        {
            IsEnabled = true,
            Duration = 1.0F,
        };

        [Description("Warning hint for the attacker when damaging to teammate.")]
        public HintConfigModel WarningOnFriendlyFire { get; set; } = new HintConfigModel
        {
            IsEnabled = true,
            Duration = 1.0F,
        };

        [Description("Hint for target when taking damage.")]
        public HintConfigModel TargetTookDamage { get; set; } = new HintConfigModel
        {
            IsEnabled = false,
            Duration = 0.7F,
        };

        [Description("Hint for target when taking damage.")]
        public CounterConfigModel AmmoCounterSettings { get; set; } = new CounterConfigModel
        {
            IsEnabled = false,
            UpdateTime = 0.1f,
            AmmoCounterSize = 35f,
            AmmoCounterPosX = -620f,
            AmmoCounterPosY = -348f,
            AmmoCounterPosLink = "left",
            AmmoCounterDesign = "<color=%player_role_color%><b>🧨 | %current_ammo% / %max_ammo%</b></color>"
        };
    }
}
