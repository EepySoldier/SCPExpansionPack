using Neuron.Core.Events;
using Neuron.Core.Meta;
using Ninject;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Events;
using Synapse3.SynapseModule.Map;
using Synapse3.SynapseModule.Player;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCPExpansionPack
{
    [Automatic]
    public class EventHandlers : Listener
    {
        [Inject]
        public Plugin plugin { get; set; }

        [EventHandler]
        public async void Coin(DoorInteractEvent ev)
        {
            if(plugin.Config.isCoinEnabled)
            {
                if (ev.Player.Inventory.ItemInHand.ItemType == ItemType.Coin)
                {
                    if (ev.Door.IsBreakable && ev.Door.Locked == false)
                    {
                        ev.Allow = false;
                        ev.Player.Inventory.RemoveItem(ev.Player.Inventory.ItemInHand);
                        ev.Door.Locked = true;
                        for (int i = 0; i < plugin.Config.coinDuration; i++)
                        {
                            ev.Player.SendHint(plugin.Translation.CoinNotification + (plugin.Config.coinDuration - i).ToString(), (float)1.02);
                            await Task.Delay(1000);
                        }
                        ev.Door.Locked = false;
                    }
                }
            }
        }

        [EventHandler]
        public void Scp096AddTarget(Scp096AddTargetEvent ev)
        {
            if(plugin.Config.targetNotification)
            {
                ev.Player.SendBroadcast("You've become a target of SCP-096, RUN!", 3);
            }
        }

        [EventHandler]
        public async void Nuke(RoundStartEvent ev)
        {
            if(plugin.Config.isNukeEnabled)
            {
                NukeService nukeService = Synapse.Get<NukeService>();
                CassieService cassieService = Synapse.Get<CassieService>();
                await Task.Delay((plugin.Config.nukeDelay - 85) * 1000);
                cassieService.Announce(plugin.Translation.CassieMessageO5);
                await Task.Delay(60000);
                nukeService.InsidePanel.Locked = true;
                nukeService.StartDetonation();
            }
        }

        [EventHandler]
        public async void GuardsEscape(RoundStartEvent ev)
        {
            if(plugin.Config.guardsEscape)
            {
                PlayerService playerService = Synapse.Get<PlayerService>();
                while (true)
                {
                    await Task.Delay(1000);
                    foreach (SynapsePlayer player in playerService.Players.Where(player => player.RoleID == 15))
                    {
                        if (player.Position.x > 122 && player.Position.x < 127 && player.Position.z > 17 && player.Position.z < 20) player.RoleID = 13;
                    }
                }
            }
        }
    }
}
