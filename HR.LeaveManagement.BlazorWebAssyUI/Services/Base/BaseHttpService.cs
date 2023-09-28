namespace HR.LeaveManagement.BlazorWebAssyUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;

        public BaseHttpService(IClient client)
        {
                _client = client;
        }
    }
}
