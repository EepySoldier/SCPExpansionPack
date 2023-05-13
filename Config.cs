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
    }
}
