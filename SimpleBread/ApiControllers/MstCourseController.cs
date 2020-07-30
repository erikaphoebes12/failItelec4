using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleBread.ApiControllers
{
    [Authorize, RoutePrefix("api/course")]
    public class MstCourseControler : ApiController
    {
        Data.DbItelec4DataContext db = new Data.DbItelec4DataContext();
        [HttpGet, Route("list")]
        public List<Api_Models.MstCourse_ApiModel> ListCourse()
        {
            var courses = from d in db.MstCourses
                          select new Api_Models.MstCourse_ApiModel
                          {
                              Id = d.Id,
                              CourseCode = d.CourseCode,
                              Course = d.Course
                          };

            return courses.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Api_Models.MstCourse_ApiModel DetailCourse(String id)
        {

            var courses = from d in db.MstCourses
                          where d.Id == Convert.ToInt32(id)
                          select new Api_Models.MstCourse_ApiModel
                          {
                              Id = d.Id,
                              CourseCode = d.CourseCode,
                              Course = d.Course
                          };

            return courses.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddCourse(Api_Models.MstCourse_ApiModel objCourse)
        {
            try
            {
                Data.MstCourse newCourse = new Data.MstCourse
                {
                    CourseCode = objCourse.CourseCode,
                    Course = objCourse.Course
                };
                db.MstCourses.InsertOnSubmit(newCourse);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut, Route("update/{id}")]
        public HttpResponseMessage UpdateCourse(Api_Models.MstCourse_ApiModel objCourse, String Id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(Id)
                             select d;

                if (course.Any())
                {
                    var updateCourse = course.FirstOrDefault();
                    updateCourse.CourseCode = objCourse.CourseCode;
                    updateCourse.Course = objCourse.Course;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Course not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete, Route("delete/{id}")]
        public HttpResponseMessage DeleteCourse(String Id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(Id)
                             select d;

                if (course.Any())
                {
                    db.MstCourses.DeleteOnSubmit(course.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}