using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitMarkers2
{
    public sealed class Translation : ITranslation
    {
        [Description("Hint for attacker when giving damage.")]
        public string DamageHint = @"<voffset=17em><size=20>%Damage%</size></voffset>";
        [Description("Content of the Hint for the attacker when killing a target.")]
        public string AttakerKillHint = @"<voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>";
        [Description("Content of the Warning hint for the attacker when damaging to teammate.")]
        public string FFWarningHint = @"%DamageHint%\n<size=34><color=yellow>Warning. Try not to hurt your teammates.</color></size>";
        [Description("Content of the Hint for target when taking damage.")]
        public string AttackedHint = @"<voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>";
    }
}
