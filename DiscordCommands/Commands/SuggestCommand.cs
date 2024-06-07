using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCommands.Commands
{
    public class SuggestCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "Suggest";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new();

        public List<string> Permissions => new() { "DiscordCommands.Suggest", "Suggest" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;
            if (command.Length < 2 ||  command.Length > 3)
            {
                return;
            }
            string suggestion = command[1];
            string title = command[0];
            if (Main.Instance.Configuration.Instance.Suggest.IsForum == true)
            {
                Helpers.Webhooks.SuggestForum(player, suggestion, title);
            }
            else
            {
                Helpers.Webhooks.Suggest(player, suggestion, title);
            }
        }
    }
}
