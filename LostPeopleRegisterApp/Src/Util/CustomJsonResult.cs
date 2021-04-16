using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace LostPeopleRegisterApp.Src.Util
{
    /// <summary>
    /// Klasa zawiera implementację metody, która będzie zwracała obiekt w 
    /// postaci JSON. Klasa ta naprawia problem związany z nieskończoną
    /// rekurencją (ze względu na relację między encjami) a także problem z 
    /// rozpoznawaniem atrybutuów <see cref="JsonIgnoreAttribute"/>
    /// </summary>
    public class CustomJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";


            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;


            if (Data != null)
            {
                response.Write(JsonConvert.SerializeObject(Data, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
        }
    }
}