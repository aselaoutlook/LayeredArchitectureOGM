using FCL.Cockerham.Ogsm.Entities;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
{
    public class ApiControllerBase : ApiController
    {
        public LoggedInUserDto LoggedInUser { get; set; }

        public ApiControllerBase()
        {
            var session = HttpContext.Current.Session;
            LoggedInUserDto _user = (LoggedInUserDto)session["LoggedInUser"];

            if (_user != null)
            {
                LoggedInUser = _user;
            }
            else
            {
                LoggedInUser = null;
            }
        }

        public HttpResponseMessage GenarateInternalServerError(string errmsg)
        {
            HttpError err = new HttpError(errmsg);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            return response;
        }

        public HttpResponseMessage GenarateUnauthorizedServerError(string errmsg)
        {
            HttpError err = new HttpError(errmsg);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized, err);
            return response;
        }

        //public string GetModelStateErrorsAsString(ICollection<ModelState> modelStates)
        //{
        //    string messages = string.Join(", ", modelStates
        //                                .SelectMany(x => x.Errors)
        //                                .Select(x => x.ErrorMessage));
        //    return messages;
        //}

        //public string GetModelStateErrorsAsString(ICollection<ModelState> modelStates)
        //{
        //    string messages = "";
        //    return messages;
        //}
    }
}