using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
{
    public static class ModelStateErrorExtensions
    {
        public static string GetModelStateErrorsAsString(ICollection<ModelState> modelStates)
        {
            string messages = string.Join(", ", modelStates
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            return messages;
        }
    }
}