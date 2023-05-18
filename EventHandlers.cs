using Neuron.Core.Events;
using Neuron.Core.Meta;
using Ninject;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Events;
using Synapse3.SynapseModule.Map;
using Synapse3.SynapseModule.Map.Objects;
using Synapse3.SynapseModule.Map.Rooms;
using Synapse3.SynapseModule.Player;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace SCPExpansionPack
{
    [Automatic]
    public class EventHandlers : Listener
    {
        [Inject]
        public Plugin plugin { get; set; }
        public bool shouldBlackout = true;

        [EventHandler]
        public async void CheckForGens(RoundStartEvent ev)
        {
            CassieService cassieService = Synapse.Get<CassieService>();
            MapService mapService = Synapse.Get<MapService>();
            int count = 0;
            while (true)
            {
                await Task.Delay(500);
                count = 0;
                foreach (SynapseGenerator generator in mapService.SynapseGenerators)
                {
                    if (generator.Engaged == true) count++;
                }
                if (count > 2)
                {
                    shouldBlackout = false;
                    if(plugin.Config.enabledCassieBlackout)
                    {
                        cassieService.Announce(plugin.Translation.CassieMessageBlackoutEnd);
                    }
                    break;
                }
            }
        }


        [EventHandler]
        public async void Blackout(RoundStartEvent ev)
        {
            if(plugin.Config.powerShortageEnabled)
            {
                CassieService cassieService = Synapse.Get<CassieService>();
                Random rng = new Random();
                if (new Random().Next(0, 100) < plugin.Config.blackoutChance)
                {
                    await Task.Delay(plugin.Config.initialBlackoutDelay * 1000);
                    if (plugin.Config.enabledCassieBlackout)
                    {
                        cassieService.Announce(plugin.Translation.CassieMessageBlackoutStart);
                    }
                    RoomService roomService = Synapse.Get<RoomService>();
                    while (true)
                    {
                        if (!shouldBlackout) break;
                        foreach (SynapseRoom room in roomService.Rooms)
                        {
                            if (room.ZoneType != ZoneType.Entrance && room.ZoneType != ZoneType.Surface)
                            {
                                room.TurnOffLights(rng.Next(plugin.Config.minBlackout, plugin.Config.maxBlackout));
                            }
                        }
                        await Task.Delay(rng.Next(plugin.Config.minBlackoutDelay, plugin.Config.maxBlackoutDelay) * 1000);
                    }
                }
            }
        }

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
                if(plugin.Config.enabledCassieNuke)
                {
                    await Task.Delay((plugin.Config.nukeDelay - 85) * 1000);
                    cassieService.Announce(plugin.Translation.CassieMessageO5);
                    await Task.Delay(60000);
                }
                else
                {
                    await Task.Delay(plugin.Config.nukeDelay * 1000);
                }
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
