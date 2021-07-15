using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get; set; }
        public bool ShowAction { get; set; }
        private ApplicationDbContext _dbContext;
        public CoursesViewModel()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CheckFollow(string followeeId, string userId)
        {
            var listFollowing = _dbContext.Followings.Where(c => c.FollowerId == userId).ToList();
            foreach (var i in listFollowing)
            {
                if (i.FolloweeId.Equals(followeeId))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAttend(int courseId, string userId)
        {
            var listAttend = _dbContext.Attendences.Where(c => c.AttendeeId == userId).ToList();
            foreach (var i in listAttend)
            {
                if (i.CourseId == courseId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}