using System;
using System.Collections.Generic;

namespace Recipe.Web.Data.Models
{
    public class ApiEndpoint
    {
        public ApiEndpoint() : this(string.Empty, new List<string> { })
        {
        }

        public ApiEndpoint(string baseEndpointUrl) : this(baseEndpointUrl, new List<string> { })
        {
        }

        public ApiEndpoint(string baseEndpointUrl, List<string> endpointParams)
        {
            BaseEndpointUrl = baseEndpointUrl;
            if (endpointParams is null)
                throw new ArgumentNullException(nameof(endpointParams));

            EndpointParams = endpointParams;
        }

        public string BaseEndpointUrl { get; set; }
        public List<string> EndpointParams { get; set; }
    }
}
