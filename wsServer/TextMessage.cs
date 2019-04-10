using System;
using Newtonsoft.Json;

namespace wsServer
{
    internal class TextMessage
    {
        [JsonProperty("uid")]
        public string UserID
        {
            get; set;
        }

        [JsonProperty("type")]
        public string Type
        {
            get; set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

        [JsonProperty("data")]
        public string Data
        {
            get; set;
        }

        [JsonProperty("to")]
        public string To
        {
            get; set;
        }

        public byte[] ToJsonByte()
        {
            string json = JsonConvert.SerializeObject(this);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }
    }
}
