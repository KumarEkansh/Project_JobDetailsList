namespace Job_Project.Entities
{
    public class GetJobDetailsById
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Location> location { get; set; }
        public List<Department> department { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }

    }
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class GetJobDetailsByIdList
    {
        public List<GetJobDetailsById> getJobDetailsByIdsList { get; set; } 
    }
}
