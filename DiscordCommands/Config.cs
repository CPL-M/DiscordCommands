using Rocket.API;
using ShimmyMySherbet.DiscordWebhooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiscordCommands.Helpers
{
    public class Config : IRocketPluginConfiguration
    {
        public Suggest Suggest { get; set; }
        public Commend Commend { get; set; }
        public Praise Praise { get; set; }
        public void LoadDefaults()
        {
            Suggest = new Suggest
            {
                Webhook = "https://discordapp.com/api/webhooks/{webhook.id}/{webhook.api}",
                IsForum = true
            };
            Commend = new Commend
            {
                Webhook = "https://discordapp.com/api/webhooks/{webhook.id}/{webhook.api}"
            };
            Praise = new Praise
            {
                Webhook = "https://discordapp.com/api/webhooks/{webhook.id}/{webhook.api}"
            };
        }
    }
    public class Suggest
    {
        public string Webhook;
        public bool IsForum;
    }
    public class Commend
    {
        public string Webhook;
    }
    public class Praise
    {
        public string Webhook;
    }
}
