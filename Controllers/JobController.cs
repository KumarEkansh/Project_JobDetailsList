using Job_Project.Contract;
using Job_Project.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Job_Project.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepo;

        public JobController(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }
		[HttpGet]
		[Route("GetJobDetails")]
		public async Task<IActionResult> GetJobDetailsById(int id)
		{
			try
			{
				if (id != null)
				{
					var data =  _jobRepo.GetJobDetailsById(id);
					return Ok(new ResultDto()
					{
						Details = data,
						Status = HttpStatusCode.OK,
						Result = true,
						ResultMessage = "SuccessFul ",
					});
				}
                else
                {
					return BadRequest(new ResultDto(){
						Details = null,
						Status = HttpStatusCode.OK,
						Result= true,
						ResultMessage="Please enter a valid id in the input "
                    });
                }
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}
        [HttpPost]
		[Route("CreateNewJobDetails")]
		public async Task<IActionResult> CreateNewJobDetails(CreateNewJobsDto job)
        {
			try
			{
				if (job != null)
				{
					var data =  _jobRepo.CreateNewJobDetails(job);
					return Ok(new ResultDto()
					{
						Details = data,
						Status = HttpStatusCode.OK,
						Result = true,
						ResultMessage = "Data has been inserted  successfully",
					});
				}
				else
				{
					return BadRequest(new ResultDto()
					{
						Details = null,
						Status = HttpStatusCode.OK,
						Result = true,
						ResultMessage = "Please enter a valid Details in the input field "
					});
				}
			}
			catch (Exception ex)
			{
				//log error
				return BadRequest(new ResultDto()
				{
					Details = null,
					Status = HttpStatusCode.BadRequest,
					Result = false,
					ResultMessage = ex.Message
				});
			}
		}
        [HttpPut]
		[Route("UpdateJobDetails")]
		public async Task<IActionResult> UpdateJobDetails( int id , CreateNewJobsDto job)
        {
			try
			{
				if (id != null && job != null)
				{
					var data =  _jobRepo.UpdateJobDetails(id ,job);
					return Ok(new ResultDto()
					{
						Details = data,
						Status = HttpStatusCode.OK,
						Result = true,
						ResultMessage = "Data has been updated successfully",
					});
				}
				else
				{
					return BadRequest(new ResultDto()
					{
						Details = null,
						Status = HttpStatusCode.OK,
						Result = true,
						ResultMessage = "Please enter a valid Details in the input field "
					});
				}
			}
			catch (Exception ex)
			{
				//log error
				return BadRequest(new ResultDto()
				{
					Details = null,
					Status = HttpStatusCode.BadRequest,
					Result = false,
					ResultMessage = ex.Message
				});
			}
		}
		//[HttpGet]
		//[Route("UpdateJobDetails")]
		//public async Task<IActionResult> GetJobDetails(GetJobDetailsByPageContentDto getJobDetailsByPageContentDto)
		//{
		//	try
		//	{
		//		if (getJobDetailsByPageContentDto != null)
		//		{
		//			var data = _jobRepo.GetJobDetails(getJobDetailsByPageContentDto);
		//			return Ok(new ResultDto()
		//			{
		//				Details = data,
		//				Status = HttpStatusCode.OK,
		//				Result = true,
		//				ResultMessage = "SuccessFul ",
		//			});
		//		}
		//		else
		//		{
		//			return BadRequest(new ResultDto()
		//			{
		//				Details = null,
		//				Status = HttpStatusCode.OK,
		//				Result = true,
		//				ResultMessage = "Please enter a valid id in the input "
		//			});
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}
	}
}