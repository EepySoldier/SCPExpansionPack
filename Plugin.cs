using Neuron.Core.Plugins;
using Synapse3.SynapseModule;

namespace SCPExpansionPack
{
    [Plugin(
    Author = "LoliEnjoyeer",
    Name = "SCP Expansion Pack",
    Description = "Adds/Changes various things to/in the game",
    Version = "1.0.0"
    )]
    public class Plugin : ReloadablePlugin<Config, Translation>
    {
        public override void EnablePlugin()
        {
            Logger.Info("Expansion Pack has been enabled!");
        }

        public override void OnReload()
        {
            Logger.Info("Expansion Pack has been reloaded!");
        }
    }
}
