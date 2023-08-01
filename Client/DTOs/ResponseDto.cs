namespace Client.DTOs
{
    public class ResponseDto<Entity>
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public Entity Data { get; set; }
    }
}