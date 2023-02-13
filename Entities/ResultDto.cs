using System.Net;

namespace Job_Project.Entities
{
    public class ResultDto
    {
        public dynamic? Details { get; set; }
        public bool Result { get; set; }
        public HttpStatusCode Status { get; set; }
        public string? ResultMessage { get; set; }

    }
}
