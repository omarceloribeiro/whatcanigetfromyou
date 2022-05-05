using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WhatCanIGetFromYouWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public NameValueCollection ValueCollection { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ValueCollection = new NameValueCollection();
        }

        public void OnGet()
        {

            string prefixCode = ".";
            foreach (var item in Request.Headers)
            {
                ValueCollection.Add("Header" + prefixCode + item.Key, item.Value);
            }
            foreach (var item in Request.QueryString.Value.Split('&'))
            {
                ValueCollection.Add("QueryString" + prefixCode + item, item);
            }
            foreach (var item in Request.Cookies)
            {
                ValueCollection.Add("Cookies" + prefixCode + item.Key, item.Value);
            }
            foreach (var item in Request.Query)
            {
                ValueCollection.Add("QueryString" + prefixCode + item.Key, item.Value);
            }

            var connection = HttpContext.Connection;
            ValueCollection.Add("Connection" + prefixCode + nameof(connection.RemoteIpAddress), connection.RemoteIpAddress.ToString());
            ValueCollection.Add("Connection" + prefixCode + nameof(connection.RemotePort), connection.RemotePort.ToString());
            ValueCollection.Add("Connection" + prefixCode + nameof(connection.Id), connection.Id.ToString());

           

        }
    }
}
