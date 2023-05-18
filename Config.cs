using Neuron.Core.Meta;
using Syml;
using System;
using System.ComponentModel;

namespace SCPExpansionPack
{
    [Automatic]
    [Serializable]
    [DocumentSection("SCP Expansion Pack Settings")]
    public class Config : IDocumentSection
    {
        [Description("Is new coin logic enabled?")]
        public bool isCoinEnabled { get; set; } = true;

        [Description("For how long doors should remain closed? (seconds)")]
        public int coinDuration { get; set; } = 8;

        [Description("Is automated nuke enabled?")]
        public bool isNukeEnabled { get; set; } = true;

        [Description("After how much time should it turn on? (seconds)")]
        public int nukeDelay { get; set; } = 1200;

        [Description("Can guards escape?")]
        public bool guardsEscape { get; set; } = true;

        [Description("Should 096 target notification appear?")]
        public bool targetNotification { get; set; } = true;

        [Description("Are powershortages enabled?")]
        public bool powerShortageEnabled { get; set; } = true;

        [Description("Minimum time of blackout (seconds)")]
        public int minBlackout { get; set; } = 0;

        [Description("Maximum time of blackout (seconds)")]
        public int maxBlackout { get; set; } = 3;

        [Description("Initial delay of first blackout (seconds)")]
        public int initialBlackoutDelay { get; set; } = 300;

        [Description("Min time between next blackout (seconds)")]
        public int minBlackoutDelay { get; set; } = 90;

        [Description("Max time between next blackout (seconds)")]
        public int maxBlackoutDelay { get; set; } = 180;

        [Description("Chance of blackouts to be enabled in certain round. (0-100)")]
        public int blackoutChance { get; set; } = 15;

        [Description("Enable Cassie Message: Nuke?")]
        public bool enabledCassieNuke { get; set; } = true;

        [Description("Enable Cassie Message: Blackout?")]
        public bool enabledCassieBlackout { get; set; } = true;
    }
}
