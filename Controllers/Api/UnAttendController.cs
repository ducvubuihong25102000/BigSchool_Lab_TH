using BigSchool.Models;
using BigSchool.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace BigSchool.Controllers.Api
{
    public class UnAttendController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public UnAttendController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult UnAttend(AttendanceDTO attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            var AttendToDel = _dbContext
                .Attendences
                .FirstOrDefault(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId);

            if (AttendToDel == null)
            {
                return BadRequest("The Attendence  is not exists!");
            }
            _dbContext.Attendences.Remove(AttendToDel);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}