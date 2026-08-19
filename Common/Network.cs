using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common
{
    public class JsonNetworkSerializer
    {
        private readonly Socket s;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine();
            return JsonSerializer.Deserialize<T>(json);
        }

        public T ReadType<T>(object podaci)
        {
            if (podaci == null)
            {
                return default(T);
            }
            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                if (podaci is JsonElement jsonElement)
                {
                    if (jsonElement.ValueKind == JsonValueKind.Number)
                    {
                        int intValue = jsonElement.GetInt32();
                        return (T)Convert.ChangeType(intValue, typeof(T));
                    }
                    else if (jsonElement.ValueKind == JsonValueKind.String)
                    {
                        string stringValue = jsonElement.GetString();
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            return (T)Convert.ChangeType(intValue, typeof(T));
                        }
                    }
                }
                throw new InvalidCastException("Не могу да конвертујем у int");
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(podaci.ToString(), typeof(T));
            }
            else if (typeof(T) == typeof(JsonElement))
            {
                return (T)podaci;
            }
            else
            {
                JsonElement jsonElement = (JsonElement)podaci;
                string jsonString = jsonElement.GetRawText();
                return JsonSerializer.Deserialize<T>(jsonString);
            }
        }

        public void Close()
        {
            try { reader?.Close(); } catch { }
            try { writer?.Close(); } catch { }
            try { stream?.Close(); } catch { }
            try { s?.Close(); } catch { }
        }
    }
}
