using System;
using System.Linq;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Admin; 

namespace GiveawayPlugin
{
    public class Giveaway : BasePlugin
    {
        public override string ModuleName => "Giveaway Plugin";
        public override string ModuleVersion => "1.0";
        public override string ModuleAuthor => "devayee";

        public override void Load(bool hotReload)
        {
       
            AddCommand("giveaway", "Starts GW", Command_Giveaway);
        }

        private void Command_Giveaway(CCSPlayerController? caller, CommandInfo command)
        {
            if (caller == null || !caller.IsValid)
                return;

          
            if (!AdminManager.PlayerHasPermissions(caller, "@css/root"))
            {
                caller.PrintToChat("[Giveaway] No Permission!");
                return;
            }

           
            var players = Utilities.GetPlayers()
                .Where(p => p != null && p.IsValid && p.Connected == PlayerConnectedState.PlayerConnected && !p.IsBot)
                .ToList();

            if (players.Count == 0)
            {
                caller.PrintToChat("[Giveaway] No players!");
                return;
            }

        
            Random rnd = new Random();
            var winner = players[rnd.Next(players.Count)];

          
            Server.PrintToChatAll($"[Giveaway] Winner is: {winner.PlayerName}!");
        }
    }
}
