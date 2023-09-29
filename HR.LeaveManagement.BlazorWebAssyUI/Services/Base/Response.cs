namespace HR.LeaveManagement.BlazorWebAssyUI.Services.Base
{
    /// <summary>
    /// Custom Response for Create, Update, Delete methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; } = true;
        public T Data { get; set; }
    }
}
