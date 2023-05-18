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
        public string CassieMessageBlackoutStart { get; set; } = "pitch_.2 .g4 .g4 pitch_.9 warning pitch_1 unauthorized chaos insurgent USBdrive access jam_050_03 detected . jam_083_3 broadcasting pitch_.8 new pitch_1 jam_10_3 message .g1 . . .g1 . . .g1 . pitch_2 . . .g2 pitch_.2 .g4 .g5 pitch_.9 Warning pitch_1 .g2 facility generator system critical error . please stand by . all science personnel please pitch_.8 die pitch_.1 .g3 pitch_1 .g1 . . .g1 . . .g1 . bell_end";
        public string CassieMessageBlackoutEnd { get; set; } = "pitch.1 .g2 . .g2 . pitch_1 generators have been engaged pitch_.8 .g2 . pitch_1 All Facility light systems working  .g1 . . . pitch_1 All class d personnel return to designated zone immediately pitch_2 end_bell";


    }
}
