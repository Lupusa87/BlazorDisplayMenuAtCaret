using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDisplayMenuAtCaret.Shared
{
    public partial class MainLayout
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected override void OnInitialized()
        {
            if (!MyJsInterop.IsReady)
            {
                MyJsInterop.jsRuntime = jsRuntime;
                MyJsInterop.IsReady = true;
            }
                   
            base.OnInitialized();
        }

    }
}
