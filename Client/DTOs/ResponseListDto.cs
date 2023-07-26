namespace Client.DTOs
{
    public class ResponseListDto<Entity>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<Entity> Data { get; set; }
    }
}