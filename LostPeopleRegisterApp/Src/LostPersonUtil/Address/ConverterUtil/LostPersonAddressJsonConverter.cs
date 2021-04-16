using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address.ConverterUtil
{
    /// <summary>
    /// Klasa jest odpowiedzialna za konfigurację sposobu przetwarzania
    /// danych w postaci JSON na obiekt typu <see cref="LostPersonAddress"/>.
    /// W zależności od tego, jakie pola są przechowywane w JSON-ie, tak na ich podstawie
    /// tworzona będzie instancja zawierająca dane teleadresowe osoby zaginionej
    /// </summary>
    public class LostPersonAddressJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(LostPersonAddress).IsAssignableFrom(objectType);
        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);

            LostPersonAddress target = Create(objectType, jObject);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }



        /// <summary>
        /// Metoda ma za zadanie utworzyc nową instację obiektu przechowującego dane teleadresowe osoby zaginionej
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        /// <see cref="LostPersonAddress"/>
        private LostPersonAddress Create(Type objectType, JObject jObject)
        {
            if (jObject.Value<string>("village") != null)
                return new VillageLostPersonAddress();
            else
                return new CityLostPersonAddress();
        }
    }
}