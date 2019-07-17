using API_MVC_Repository.Models;
using API_MVC_Repository.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_MVC_Repository.api
{
    public class StudentController : ApiController
    {
        private _IALLRepository<tblStudent> interfaceObj;
        //private List<tblStudent> students = new List<tblStudent>();

        public StudentController()
        {
            this.interfaceObj = new AllRepository<tblStudent>();
        }

        // GET: api/Student
        //[HttpGet]
        public IEnumerable<tblStudent> GetStudents()
        {
            IEnumerable<tblStudent> students = new List<tblStudent>();

            try
            {               
                students = interfaceObj.GetModel().ToList();
            }
            catch
            {
                students = null;
            }
            return students;
        }

        //[ResponseType(typeof(tblStudent))]
        //[Route("api/SaveStudent")]
        [HttpPost]
        public HttpResponseMessage SaveStudent(tblStudent student)
        {
            int result = 0;
            try
            {
                //dbContext.tblStudents.Add(astudent);
                //dbContext.SaveChanges();
                interfaceObj.InsertModel(student);
                interfaceObj.Save();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        //[ResponseType(typeof(tblStudent))]
        //[Route("api/UpdateStudent")]
        [HttpPut]
        public HttpResponseMessage UpdateStudent(tblStudent student)
        {
            int result = 0;
            try
            {
                interfaceObj.UpdateModel(student);
                interfaceObj.Save();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        //[ResponseType(typeof(tblStudent))]
        //[Route("api/DeleteStudent")]
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                interfaceObj.DeleteModel(id);
                interfaceObj.Save();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

       [Route("api/Student/GetStudentByID/{studentID}")]
        //[ResponseType(typeof(tblStudent))]
        [HttpGet]
        public tblStudent GetStudentByID(int studentID)
        {
            tblStudent student = null;
            try
            {
                student = interfaceObj.GetModelByID(studentID);

            }
            catch (Exception e)
            {
                student = null;
            }

            return student;
        }
    }
}
