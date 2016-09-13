using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarManager.WebCore.MVC
{
    public class JsonNetResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                var response = context.HttpContext.Response;
                response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();//契约
                jsonSerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                string json = JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializerSettings);
                response.Write(json);
            }

            base.ExecuteResult(context);
        }

    }
}
