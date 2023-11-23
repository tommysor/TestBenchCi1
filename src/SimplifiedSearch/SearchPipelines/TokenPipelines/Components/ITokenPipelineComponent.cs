using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSearch.SearchPipelines.TokenPipelines.Components
{
    internal interface ITokenPipelineComponent
    {
        string[] RunAsync(string[] value);
    }
}
