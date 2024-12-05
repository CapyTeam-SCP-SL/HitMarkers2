using System.ComponentModel;

namespace HitMarkers2.Features
{
    public sealed class CounterConfigModel
    {
        [Description("Should the ammo counter be enabled?")]
        public bool IsEnabled { get; set; }

        [Description("Ammo Counter Update Time.")]
        public float UpdateTime { get; set; }
        [Description("Ammo Counter Size.")]
        public float AmmoCounterSize { get; set; }
        [Description("Setting the Ammo Counter X Axis Position")]
        public float AmmoCounterPosX { get; set; }
        [Description("Setting the Ammo Counter Y Axis Position.")]
        public float AmmoCounterPosY { get; set; }
        [Description("Linking the Ammo Counter position on the screen.")]
        public string AmmoCounterPosLink { get; set; }
        [Description("Ammo Counter Design.")]
        public string AmmoCounterDesign { get; set; }
    }
}
