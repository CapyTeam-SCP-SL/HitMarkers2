using System.ComponentModel;

namespace HitMarkers2.Features
{
    public sealed class HintConfigModel
    {
        [Description("Should a hint be displayed?")]
        public bool IsEnabled { get; set; }

        [Description("Content of the Hint to be displayed.")]
        public string Message { get; set; }

        [Description("Hint display duration.")]
        public float Duration { get; set; }
    }
}
