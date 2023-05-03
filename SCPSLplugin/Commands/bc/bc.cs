using CommandSystem;
using Exiled.API.Features;
using System;

namespace SCPSLPLugin.Commands.bc {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class hintc : ParentCommand
    {
        public hintc() => LoadGeneratedCommands();

        public override string Command { get; } = "bc";

        public override string[] Aliases { get; } = new string[] { "broadcast" };

        public override string Description { get; } = "Sends a broadcast to every player in the server";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 2)
            {
                response = "Usage: adminbroadcast (time) (message)";
                return false;
            }

            if (!ushort.TryParse(arguments.At(0), out ushort t))
            {
                response = $"Invalid value for broadcast time: {arguments.At(0)}";
                return false;
            }

            string str = "";
            for (int i = 1; i < arguments.Count; i++) str += arguments.At(i);

            Log.Info(string.Format("Following message has been broadcasted: {0}", str));
            foreach (Player pl in Player.List)
            {
                pl.Broadcast(t, str);
            }

            response = $"Message sent to all players";
            return true;
        }
    }
}