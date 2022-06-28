namespace PatikaExample1.Models
{
    public class MetaData
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class ResponseModel<T>
    {
        public MetaData metaData { get; set; }
        public T data { get; set; }
        
    }
}
