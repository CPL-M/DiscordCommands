using Rocket.Unturned.Player;
using SDG.Unturned;
using ShimmyMySherbet.DiscordWebhooks.Models;
using ShimmyMySherbet.DiscordWebhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Rocket.Core.Logging;
using static UnityEngine.GraphicsBuffer;

namespace DiscordCommands.Helpers
{
    public class Webhooks
    {
        public static void SuggestForum(UnturnedPlayer caller, string suggestion, string title)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)(async _ =>
            {
                try
                {
                    var channel = new DiscordWebhookChannel(Main.Instance.Configuration.Instance.Suggest.Webhook);

                    var message = new WebhookMessage()
                    .CreateThread(title)
                    .PassEmbed()
                    .WithTitle(title)
                    .WithColor(EmbedColor.LightGoldenrodYellow)
                    .WithAuthor($"Suggestor: {caller.CharacterName}", "https://steamcommunity.com/profiles/" + caller.CSteamID.ToString())
                    .WithDescription(suggestion)
                    .WithFooter("[DiscordCommands] " + DateTime.Now.ToString("dddd, dd MMMM, yyyy"))
                    .Finalize();

                    var sent = await channel.PostMessageAsync(message);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Exception occurred in Suggest method");
                }
            }));
        }
        public static void Suggest(UnturnedPlayer caller, string suggestion, string title)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)(async _ =>
            {
                try
                {
                    var channel = new DiscordWebhookChannel(Main.Instance.Configuration.Instance.Suggest.Webhook);

                    var message = new WebhookMessage()
                    .PassEmbed()
                    .WithTitle("Suggestion")
                    .WithColor(EmbedColor.LightGoldenrodYellow)
                    .WithField(title, suggestion)
                    .WithField("From", $"[{caller.CharacterName}](https://steamcommunity.com/profiles/{caller.CSteamID})", false)
                    .WithFooter("[DiscordCommands] " + DateTime.Now.ToString("dddd, dd MMMM, yyyy"))
                    .Finalize();

                    var sent = await channel.PostMessageAsync(message);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Exception occurred in Suggest method");
                }
            }));
        }
        public static void Commend(UnturnedPlayer caller, UnturnedPlayer target, string reason)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)(async _ =>
            {
                try
                {
                    var channel = new DiscordWebhookChannel(Main.Instance.Configuration.Instance.Commend.Webhook);

                    var message = new WebhookMessage()
                    .PassEmbed()
                    .WithTitle("Player Commendation")
                    .WithColor(EmbedColor.DarkOliveGreen)
                    .WithField("Player", $"[{target.CharacterName}](https://steamcommunity.com/profiles/{target.CSteamID})", true)
                    .WithField("Reason", reason, false)
                    .WithField("From", $"[{caller.CharacterName}](https://steamcommunity.com/profiles/{caller.CSteamID})", false)
                    .WithFooter("[DiscordCommands] " + DateTime.Now.ToString("dddd, dd MMMM, yyyy"))
                    .Finalize();

                    var sent = await channel.PostMessageAsync(message);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Exception occurred in Suggest method");
                }
            }));
        }
        public static void Praise(UnturnedPlayer caller, UnturnedPlayer target, string reason)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)(async _ =>
            {
                try
                {
                    var channel = new DiscordWebhookChannel(Main.Instance.Configuration.Instance.Praise.Webhook);

                    var message = new WebhookMessage()
                    .PassEmbed()
                    .WithTitle("Staff Praise")
                    .WithColor(EmbedColor.MediumSpringGreen)
                    .WithField("Staff Member", $"[{target.CharacterName}](https://steamcommunity.com/profiles/{target.CSteamID})", true)
                    .WithField("Reason", reason, false)
                    .WithField("From", $"[{caller.CharacterName}](https://steamcommunity.com/profiles/{caller.CSteamID})", false)
                    .WithFooter("[DiscordCommands] " + DateTime.Now.ToString("dddd, dd MMMM, yyyy"))
                    .Finalize();

                    var sent = await channel.PostMessageAsync(message);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Exception occurred in Suggest method");
                }
            }));
        }
    }
}
