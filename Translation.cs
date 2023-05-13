using Neuron.Core.Meta;
using Neuron.Modules.Configs.Localization;
using System;

namespace SCPExpansionPack
{
    [Automatic]
    [Serializable]
    public class Translation : Translations<Translation>
    {
        public string CoinNotification { get; set; } = "Doors are locked for: ";
        public string CassieMessageO5 { get; set; } = "cassie_sl pitch_.2 .g4 .g4 pitch_1 . Facility diagnostic anomaly detected . .g2 o 5 password accepted .g3 . automatic warhead detonation sequence authorized pitch_.9 .g3 . pitch_1 detonation start tminus 1 minute . all personnel evacuate pitch_.8 . .g1 . .g1 . .g1 pitch_1 bell_end";
    }
}
