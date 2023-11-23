using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unidecode.NET;

namespace SimplifiedSearch.SearchPipelines.TokenPipelines.Components
{
    internal class AsciiFoldingFilter : ITokenPipelineComponent
    {
        public string[] RunAsync(params string[] value)
        {
            var len = value.Length;
            for (var i = 0; i < len; i++)
            {
                var asciiString = value[i].Unidecode();
                value[i] = asciiString;
            }

            return value;
        }
    }
}
