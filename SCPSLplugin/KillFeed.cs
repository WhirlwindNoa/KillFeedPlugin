using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace SCPSLplugin
{
    public class KillFeed
    {
        // 1 tick = 10ms
        // message, TTL (in ticks)
        Queue<string> messages = new Queue<string>();
        public string kfHint;

        // player A kills player B
        public void updateKillFeed()
        {
            kfHint = string.Format("<voffset={0}em><size=85%><line-height=1.5em><align=left><indent=65%>{1}",
                        37 - messages.Count * 1.5,
                        string.Join("<br>", messages)
            );

            foreach (Player player in Player.List)
            {
                player.ShowHint(kfHint, 100f);
            }
        }
        
        public void addEventMessage(string message)
        {
            messages.Enqueue(message);
            updateKillFeed();

            Timing.CallDelayed(10f, () =>
            {
                messages.Dequeue();
                updateKillFeed();
            });
        }
    }
}
