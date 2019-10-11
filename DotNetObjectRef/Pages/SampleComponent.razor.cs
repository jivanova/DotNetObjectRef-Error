using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace DotNetObjectRef.Pages
{
    public class SampleComponentBase: ComponentBase, IDisposable
    {
        private protected readonly string id = Guid.NewGuid().ToString();

        [Inject] 
        IJSRuntime JsRuntime { get; set; }

        private DotNetObjectReference<SampleComponentBase> Reference { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (Reference == null)
                {
                    Reference = DotNetObjectReference.Create(this);
                }

                await JsRuntime.InvokeAsync<object>(
                        "exampleJsFunctions.SubscribeEvents", id, Reference);
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        public void Dispose()
        {
            if (Reference != null)
            {
                Reference.Dispose();
            }
        }

        [JSInvokable]
        public void Close()
        {
            StateHasChanged();
        }
    }
}
