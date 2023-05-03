using CommandSystem;
using Exiled.API.Features;
using System;

namespace SCPSLPLugin.Commands.hint {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class hintc : ParentCommand
    {
        public hintc() => LoadGeneratedCommands();

        public override string Command { get; } = "hint";

        public override string[] Aliases { get; } = new string[] { };

        public override string Description { get; } = "Sends a hint to every player in the server";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 2)
            {
                response = "Usage: hint (id) (time) (message)";
                return false;
            }

            if (!ushort.TryParse(arguments.At(0), out ushort id))
            {
                response = $"Invalid value for broadcast time: {arguments.At(0)}";
                return false;
            }
            if (!ushort.TryParse(arguments.At(1), out ushort t))
            {
                response = $"Invalid value for broadcast time: {arguments.At(0)}";
                return false;
            }

            string str = "";
            for (int i = 2; i < arguments.Count; i++) str += arguments.At(i) + " ";

            Log.Info(string.Format("Following message has been broadcasted: {0}", str));

            Player pl = Player.Get(id);
            pl.ShowHint(str, t);

            response = $"Message sent to all players";
            return true;
        }
    }
}