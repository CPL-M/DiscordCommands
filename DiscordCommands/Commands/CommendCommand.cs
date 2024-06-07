using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCommands.Commands
{
    public class CommendCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "Commend";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new();

        public List<string> Permissions => new() { "DiscordCommands.Commend", "Commend" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;
            if (command.Length < 2 || command.Length > 2)
            {
                return;
            }
            string reason = command[1];
            string targetplayer = command[0];
            UnturnedPlayer target = UnturnedPlayer.FromName(targetplayer);
            Helpers.Webhooks.Commend(player, target, reason);
        }
    }
}
