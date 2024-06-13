using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace GestorPaciente.Core.Application.Helpers
{
    public static class SessionHelper
    {
        public static void SetSession<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
