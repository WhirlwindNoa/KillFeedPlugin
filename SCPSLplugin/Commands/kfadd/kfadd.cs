using CommandSystem;
using SCPSLplugin;
using System;

namespace SCPSLPLugin.Commands.kfadd
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class kfadd : ParentCommand
    {
        public kfadd() => LoadGeneratedCommands();

        public override string Command { get; } = "kfadd";

        public override string[] Aliases { get; } = new string[] { };

        public override string Description { get; } = "Adds a message to the killfeed";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1)
            {
                response = "Usage: kfadd (message)";
                return false;
            }

            string str = string.Join(" ", arguments);

            EventHandlers.killfeed.addEventMessage(str);

            response = $"Message added to the killfeed";
            return true;

        }
    }
}