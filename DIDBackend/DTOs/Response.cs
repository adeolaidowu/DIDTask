namespace DIDBackend.DTOs
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public T Data { get; set; }
    }
}
