using Newtonsoft.Json;

namespace eClaims.Web.Extensions
{
    public static class JsonConvertExtensions<T> where T : class
    {
        public static bool Deserialize(dynamic objToDeserialize, out T deserializedObject)
        {
            try
            {
                deserializedObject = JsonConvert.DeserializeObject<T>(objToDeserialize);
                return true;
            }
            catch
            {
                deserializedObject = default(T);
                return false;
            }
        }

    }
}
