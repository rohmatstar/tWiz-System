namespace Client.DTOs
{
    public class ResponseDto<Entity>
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public Entity Data { get; set; }
    }
}