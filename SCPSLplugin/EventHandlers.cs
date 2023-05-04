using exiledPlugin;
using MEC;

using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Warhead;

namespace SCPSLplugin
{
    public class EventHandlers
    {
        public Plugin Plugin;
        public EventHandlers(Plugin plugin) => Plugin = plugin;
        public static KillFeed killfeed = new KillFeed();

        internal void OnPlayerJoin(JoinedEventArgs ev) {
            Timing.CallDelayed(3f, () =>
            {
                Log.Info(string.Format("Player {0} just joined the game!", ev.Player.Nickname));
            });
        }

        internal void OnPlayerDied(DiedEventArgs ev)
        {
            if (ev.Attacker is null)
            {
                killfeed.addEventMessage(ev.Player.Nickname + " died");
                return;
            }

            killfeed.addEventMessage(ev.Player.Nickname + " was killed by " +  ev.Attacker.Nickname);
            return;
        }

        internal void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            killfeed.addEventMessage("Generator has been activated");
        }

        internal void OnDecontamination(DecontaminatingEventArgs ev)
        {
            killfeed.addEventMessage("LCZ has been closed");
        }

        internal void OnWarheadDetonation(DetonatingEventArgs ev)
        {
            killfeed.addEventMessage("Alpha Warhead is being detonated");
        }

        internal void OnStoppingWarhead(StoppingEventArgs ev)
        {
            killfeed.addEventMessage("Alpha Warhead has been deactivated");
        }

        internal void OnStartingWarhead(StartingEventArgs ev)
        {
            killfeed.addEventMessage("Alpha Warhead has been activated");
        }
    }
}
