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

        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

        [JsonProperty("type")]
        public string Type
        {
            get; set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get; set;
        }

        [JsonProperty("to")]
        public string To
        {
            get; set;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
