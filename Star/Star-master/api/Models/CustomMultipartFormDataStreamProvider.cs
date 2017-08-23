using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace api.Models
{
    public class CustomMultipartFormDataStreamProvider: MultipartFormDataStreamProvider
    {
        
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }
        public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize)  
        : base(rootPath, bufferSize)  
    {
        }
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return base.GetLocalFileName(headers) + ".jpg";
        }
    }
}