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

    public class LoggingHandler :DelegatingHandler {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            MessageBox.Show(request.ToString());
            if(request.Content != null) {
                MessageBox.Show(await request.Content.ReadAsStringAsync());
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            MessageBox.Show("Here "+response.ToString());
            /*
            if(response.Content != null) {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }*/
            MessageBox.Show(response.Content.ToString());
            MessageBox.Show(await response.Content.ReadAsStringAsync());


            return response;
        }
    }



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

            using var formContent = new MultipartFormDataContent
{
        { new StringContent("1"), "itemcount" },
        { new StringContent("1599372051"), "publishedfileids%5B0%5D"}
    };

            var request = new HttpRequestMessage {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{BASE_URL}/ISteamRemoteStorage/GetCollectionDetails/v1/?key=XXX&input_json={{\"itemcount:1,publishedfileids[0]:[1599372051]\"}}"),
                Content = formContent,
            };



            try {
                using HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()));

                HttpResponseMessage response = await client.SendAsync(request);

                // Ensure successful response
                response.EnsureSuccessStatusCode();

                // Read and process the response if needed
                string responseBody = await response.Content.ReadAsStringAsync();
                //MessageBox.Show(responseBody);
            }
            catch(HttpRequestException e) {
                MessageBox.Show($"Request error: {e.Message}");
            }
            catch(Exception e) {
                MessageBox.Show($"General error: {e.Message}");
            }

        }
    }
}
