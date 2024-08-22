/**
 * SteamController.cs
 * Controls interaction with Steam
 * Ryan Broman <ryan@broman.dev>
 * 2024-08-21
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using DayZRPLauncher.Steam;
using System.Text.Json;
using System.Net;

namespace DayZRPLauncher {
    internal class SteamController {
        /// <summary>
        ///  There does exist a few Steam libraries, but handling Auth and whatnot is completely undocumented
        ///  in these libraries and are more intended for gamedevs than for interfacing with Steam.
        ///  
        ///  This class uses published API endpoints to validate installed mod timestamp == last updated
        /// </summary>
        static readonly string BASE_URL = "https://api.steampowered.com";
        static readonly string? API_KEY = MainWindow.parameters.Params.FirstOrDefault(x => x.Label == Constants.API_KEY)?.Value as string;
        static readonly HttpClient client = new();
        public static SteamController Instance { get; private set; } = new SteamController();


        private SteamController() {

        }

        public async void VerifyMods() {
            // I spent 3 hours trying to work with the Steam API tonight. I give up.

            // insert working code here

        }
    }
}
