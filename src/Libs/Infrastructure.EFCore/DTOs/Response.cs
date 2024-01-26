namespace Infrastructure.EFCore.DTOs
{
    public class Response<TEntity>
    {
        public TEntity Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsError { get; set; }
    }
}
