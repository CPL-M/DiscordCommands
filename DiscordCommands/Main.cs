using DiscordCommands.Helpers;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCommands
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance { get; private set; }
        protected override void Load()
        {
            Instance = this;

            Logger.Log("==========|| DiscordCommands Loaded ||==========", ConsoleColor.Magenta);
            Logger.Log($"               Version: {Assembly.GetName().Version}", ConsoleColor.Magenta);
        }
    }
}
