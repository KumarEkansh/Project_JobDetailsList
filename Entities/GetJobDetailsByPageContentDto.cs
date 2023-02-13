namespace Job_Project.Entities
{
    public class JobResponse
    {
        public int SrNo { get; set; }
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public int departmentId { get; set; }
        public int locationId { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }

    public class JobNestedResponse
    {
        public int total { get; set; }
        public JobResponse data { get; set; }
    }
    public class JobREsponseList
    {
        public List<JobNestedResponse> data { get; set; }
    }
    public class GetJobByPageContentDto
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string? SortString { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
    }


}
