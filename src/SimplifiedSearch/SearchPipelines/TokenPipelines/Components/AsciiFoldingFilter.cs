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
            var inputs = new string[len];
            for (var i = 0; i  < len; i++)
            {
                inputs[i] = value[i];
            }
            var result1 = new List<string>();
            for (var i = 0; i < len; i++)
            {
                var asciiString = inputs[i].Unidecode();
                // value[i] = asciiString;
                result1.Add(asciiString);
            }

            return result1.ToArray();
        }
    }
}
