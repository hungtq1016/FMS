namespace Share.Entities
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsError { get; set; }
    }
}
