using Dapper;
using Job_Project.Context;
using Job_Project.Contract;
using Job_Project.Entities;
using System.Data;

namespace Job_Project.Repository
{
    public class JobRepository: IJobRepository
    {
        private readonly DapperContext _context;

        public JobRepository(DapperContext context)
        {
            _context = context;
        }
        public ResultDto GetJobDetailsById(int id)
        {
            try
            {
                var para = new DynamicParameters();
                GetJobDetailsByIdList getJobDetails = new GetJobDetailsByIdList();
                para.Add("@ID", id);
                using (var connection = _context.CreateConnection())
                {
                    var data = connection.ExecuteReader("sp_GetJobsById", para, null, commandType: CommandType.StoredProcedure);
                    while (data != null)
                    {
                        GetJobDetailsById GetJobDetailsById = new GetJobDetailsById();
                        Location location = new Location();
                        Department department = new Department();
                        GetJobDetailsById.Id = Convert.ToInt32(data["Id"]);
                        GetJobDetailsById.Code = Convert.ToString(data["Code"]);
                        GetJobDetailsById.Title = Convert.ToString(data["Title"]);
                        GetJobDetailsById.Description = Convert.ToString(data["Description"]);
                        GetJobDetailsById.location[0].Id = Convert.ToInt32(data["locationId"]);
                        GetJobDetailsById.location[1].Title = Convert.ToString(data["locationTitle"]);
                        GetJobDetailsById.location[2].City = Convert.ToString(data["locationCity"]);
                        GetJobDetailsById.location[3].State = Convert.ToString(data["locationState"]);
                        GetJobDetailsById.location[4].Country = Convert.ToString(data["locationCountry"]);
                        GetJobDetailsById.location[5].Zip = Convert.ToInt32(data["locationZip"]);
                        GetJobDetailsById.department[0].Id = Convert.ToInt32(data["departmentId"]);
                        GetJobDetailsById.department[1].Title = Convert.ToString(data["jobTitle"]);
                        GetJobDetailsById.PostedDate = Convert.ToDateTime(data["PostedDate"]);
                        GetJobDetailsById.ClosingDate = Convert.ToDateTime(data["ClosingDate"]);

                        getJobDetails.getJobDetailsByIdsList.Add(GetJobDetailsById);
                    }
                    if (getJobDetails != null)
                    {
                        return new ResultDto()
                        {
                            Details = getJobDetails,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = true,
                            ResultMessage = "Data is successfully fetched"
                        };
                    }
                    else
                    {
                        return new ResultDto()
                        {
                            Details = null,
                            Status = System.Net.HttpStatusCode.NoContent,
                            Result = false,
                            ResultMessage = " no Data Found"
                        };
                    }
                }
            }

            catch (Exception ex)
            {
                return new ResultDto()
                {
                    Details = null,
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Result = false,
                    ResultMessage = ex.Message
                };
            }        
                      
        }
        public ResultDto CreateNewJobDetails(CreateNewJobsDto job)
        {
            try
            {
                var para = new DynamicParameters();
                CreateNewJobsDto getJobDetails = new CreateNewJobsDto();
                para.Add("@Title", job.Title);
                para.Add("@Description", job.Description);
                para.Add("@LocationId", job.LocationId);
                para.Add("@DepartmentId", job.DepartmentId);
                para.Add("@ClosingDate", job.ClosingDate);
                using (var connection = _context.CreateConnection())
                {
                    string data = connection.ExecuteScalar<string>("sp_AddJobs", para, null, commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        return new ResultDto()
                        {
                            Details = data,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = true,
                            ResultMessage = " Data has been inseerted SuccessFully"
                        };
                    }
                    else
                    {
                        return new ResultDto()
                        {
                            Details = null,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = false,
                            ResultMessage = "Data has  not  been inserted SuccessFully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    Details = null,
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Result = false,
                    ResultMessage = ex.Message
                };
            }
        }
        public ResultDto UpdateJobDetails(int id, CreateNewJobsDto job)
        {
            try
            {
                var para = new DynamicParameters();
                CreateNewJobsDto getJobDetails = new CreateNewJobsDto();
                para.Add("@ID", id);
                para.Add("@Title", job.Title);
                para.Add("@Description", job.Description);
                para.Add("@LocationId", job.LocationId);
                para.Add("@DepartmentId", job.DepartmentId);
                para.Add("@ClosingDate", job.ClosingDate);
                using (var connection = _context.CreateConnection())
                {
                    string data = connection.ExecuteScalar<string>("sp_UpdateJobs", para, null, commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        return new ResultDto()
                        {
                            Details = data,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = true,
                            ResultMessage = " Data has been Updated SuccessFully"
                        };
                    }
                    else
                    {
                        return new ResultDto()
                        {
                            Details = null,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = false,
                            ResultMessage = "Data has  not been Updated SuccessFully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    Details = null,
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Result = false,
                    ResultMessage = ex.Message
                };
            }
        }
        public ResultDto GetJobDetails(GetJobByPageContentDto getJobByPageContentDto)
        {
            try
            {
                var para = new DynamicParameters();

                para.Add("@page", getJobByPageContentDto.Page);
                para.Add("@size", getJobByPageContentDto.Size);
                para.Add("@sortString", getJobByPageContentDto.SortString);
                para.Add("@LocationId", getJobByPageContentDto.LocationId);
                para.Add("@DepartmentId", getJobByPageContentDto.DepartmentId);
                JobREsponseList jobNestedResponse1 = new JobREsponseList();
                using (var connection = _context.CreateConnection())
                {
                    string data = connection.ExecuteScalar<string>("sp_GetJobList", para, null, commandType: CommandType.StoredProcedure);
                    while (data != null)
                    {

                        JobNestedResponse jobNestedResposne = new JobNestedResponse();
                        jobNestedResposne.total = Convert.ToInt32("Total");
                        jobNestedResposne.data.SrNo = Convert.ToInt32("SrNo");
                        jobNestedResposne.data.id = Convert.ToInt32("Id");
                        jobNestedResposne.data.locationId = Convert.ToInt32("LocationId");                        
                        jobNestedResposne.data.departmentId = Convert.ToInt32("DepartmentId");
                        jobNestedResposne.data.postedDate = Convert.ToDateTime("PostedDate");
                        jobNestedResposne.data.closingDate = Convert.ToDateTime("ClosingDate");
                        jobNestedResponse1.data.Add(jobNestedResposne);
                        //getJobByPageContentNestedList.getJobDetailsByPageContentDtos.Add(getJobDetailsByPageContentDto);
                    }




                    if (data != null)
                    {
                        return new ResultDto()
                        {
                            Details = data,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = true,
                            ResultMessage = " Data has been Updated SuccessFully"
                        };
                    }
                    else
                    {
                        return new ResultDto()
                        {
                            Details = null,
                            Status = System.Net.HttpStatusCode.OK,
                            Result = false,
                            ResultMessage = "Data has  not been Updated SuccessFully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    Details = null,
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Result = false,
                    ResultMessage = ex.Message
                };
            }
        }
    }
}
