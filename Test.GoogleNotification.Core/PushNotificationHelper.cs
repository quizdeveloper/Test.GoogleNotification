using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.GoogleNotification.Core
{
    public class PushNotificationHelper
    {
        private static Uri notificationsApiURL = new Uri("https://fcm.googleapis.com/fcm/send");
        private static string ServerKey = "AAAANuwoLDE:APA91bH-rR7bUe82uEG4WopRdAKuE2cAG0tNeOWHzk1vrt5VYgiBIBTkZPVACbjQqhThR29H30wGaWzn7uMuNSgR2cQykJpoAXhc2ZLXlllYB3zVm0xtZS0VptPa0dtoBHgKCCE4U_AV";

        public static async Task<bool> SendPushNotification(string[] deviceTokens, string title, string body, object data, string link ="", string icon ="")
        {
            bool sent = false;

            if (deviceTokens.Count() > 0)
            {
                //Object creation

                var messageInformation = new Message()
                {
                    notification = new Notification()
                    {
                        title = title,
                        body = body,
                        click_action = link,
                        icon = icon
                    },
                    data = data,
                    registration_ids = deviceTokens
                };

                //Object to JSON STRUCTURE => using Newtonsoft.Json;
                string jsonMessage = JsonConvert.SerializeObject(messageInformation);

                /*
                 ------ JSON STRUCTURE ------
                 {
                    notification: {
                                    title: "",
                                    text: ""
                                    },
                    data: {
                            action: "Play",
                            playerId: 5
                            },
                    registration_ids = ["id1", "id2"]
                 }
                 ------ JSON STRUCTURE ------
                 */

                //Create request to Firebase API
                var request = new HttpRequestMessage(HttpMethod.Post, notificationsApiURL);

                request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                HttpResponseMessage result;
                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                    sent = sent && result.IsSuccessStatusCode;
                }
            }

            return sent;
        }

    }

    public class Message
    {
        public string[] registration_ids { get; set; }
        public Notification notification { get; set; }
        public object data { get; set; }
    }

    public class Notification
    {
        public string title { get; set; }
        public string body { get; set; }
        public string icon { get; set; }
        public string click_action { get; set; }
    }
}
