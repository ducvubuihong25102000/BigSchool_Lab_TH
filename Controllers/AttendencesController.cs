using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendencesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendences.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists !");

            var attendance = new Attendence
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendences.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _dbContext.Attendences
                .SingleOrDefault(a => a.AttendeeId == userId && a.CourseId == id);

            if (attendance == null)
                return NotFound();

            _dbContext.Attendences.Remove(attendance);
            _dbContext.SaveChanges();

            return Ok(id);
        }
    }
}
