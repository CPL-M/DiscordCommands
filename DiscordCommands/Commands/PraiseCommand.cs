using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCommands.Commands
{
    public class PraiseCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "Praise";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new();

        public List<string> Permissions => new() { "DiscordCommands.Praise", "Praise" };

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
                Helpers.Webhooks.Praise(player, target, reason);
        }
    }
}
