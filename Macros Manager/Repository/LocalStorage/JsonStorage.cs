using Newtonsoft.Json;

namespace Macros_Manager.Repository.LocalStorage
{
    public static class JsonStorage
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
        private const Formatting _indented = Formatting.Indented;

        public static string SerializeWithType(object a_objectToSerialize)
        {
            return JsonConvert.SerializeObject(a_objectToSerialize, _indented, _settings);
        }

        public static T DeserializeWithType<T>(string a_objectToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(a_objectToDeserialize, _settings);
        }

        public static string SerializeData(object a_objectToSerialize)
        {
            return JsonConvert.SerializeObject(a_objectToSerialize, _indented);
        }

        public static T DeserializeData<T>(string a_objectToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(a_objectToDeserialize);
        }
    }
}