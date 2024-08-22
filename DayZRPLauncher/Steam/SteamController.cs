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

namespace DayZRPLauncher {
    internal class SteamController {
        /// <summary>
        ///  There does exist a few Steam libraries, but handling Auth and whatnot is completely undocumented
        ///  in these libraries and are more intended for gamedevs than for interfacing with Steam.
        ///  
        ///  This class uses undocumented (officially) API endpoints to validate mods
        /// </summary>
        static readonly string BASE_URL = "https://api.steampowered.com/";
        static readonly string? API_KEY = MainWindow.parameters.Params.FirstOrDefault(x => x.Label == Constants.API_KEY)?.Value as string;
        static readonly HttpClient client = new HttpClient();
        public static SteamController Instance { get; private set; } = new SteamController();


        private SteamController() {

        }

        public string GetUrl(string iface, string endpoint) {
            return $"{BASE_URL}/{iface}/{endpoint}/v1/?key={API_KEY}";
        }
        
        public string BuildCollectionUrl(string iface, string endpoint, ulong id) {
            var bse = $"{BASE_URL}/{iface}/{endpoint}/v1/?key={API_KEY}";
            return $"{bse}&collectioncount=1&publishedfileids%5B0%5D={id}";
        }

        public string BuildItemUrl(string iface, string endpoint, ulong id) {

        }

        public async Task<string> GetCollectionDetails(ulong id) {
            var url = $"{BuildCollectionUrl("ISteamRemoteStorage", "GetCollectionDetails", id)}";
            var resp = await client.PostAsync(GetUrl("ISteamRemoteStorage", "GetCollectionDetails"), null);
            return await resp.Content.ReadAsStringAsync();
        }

        public async void VerifyMods() {
            MessageBox.Show(await GetCollectionDetails(Constants.DRP_MODLIST_ID));
        }
    }
}
