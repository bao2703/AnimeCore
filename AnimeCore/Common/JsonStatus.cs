using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Common
{
    public class JsonStatus
    {
        public static JsonResult Ok => new JsonResult(new {status = "Ok"});
    }
}