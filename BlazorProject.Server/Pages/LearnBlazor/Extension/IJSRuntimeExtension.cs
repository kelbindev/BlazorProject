using Microsoft.JSInterop;

namespace BlazorProject.Server.Pages.LearnBlazor.Extension
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRunTime, string message)
        {
            await jsRunTime.InvokeVoidAsync("showToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRunTime, string message)
        {
            await jsRunTime.InvokeVoidAsync("showToastr", "error", message);
        }

        public static async ValueTask ToastrWarning(this IJSRuntime jsRunTime, string message)
        {
            await jsRunTime.InvokeVoidAsync("showToastr", "warning", message);
        }
    }
}
