using Job_Project.Entities;

namespace Job_Project.Contract
{
    public interface IJobRepository
    {
        
        public ResultDto GetJobDetailsById(int id);
        public ResultDto CreateNewJobDetails(CreateNewJobsDto job);
        public ResultDto UpdateJobDetails(int id, CreateNewJobsDto job );
        //public ResultDto GetJobDetails(GetJobDetailsByPageContentDto getJobDetailsByPageContentDto);
    }
}
