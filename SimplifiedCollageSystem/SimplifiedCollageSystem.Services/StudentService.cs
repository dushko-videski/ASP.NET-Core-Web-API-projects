using SimplifiedCollageSystem.DataAccess;
using SimplifiedCollageSystem.DomainModels;
using SimplifiedCollageSystem.Models;
using SimplifiedCollageSystem.Services.Exceptions;
using SimplifiedCollageSystem.Services.Interfaces;
using System.Collections.Generic;

namespace SimplifiedCollageSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }



        public void RegisterStudent(StudentModel studentModel)
        {

            if (string.IsNullOrWhiteSpace(studentModel.FullName))
            {
                throw new StudentException("Must fill in full name!");
            }

            Student student = new Student()
            {
                StudentNumber = studentModel.StudentNumber,
                FullName = studentModel.FullName,
                EmailAddress = studentModel.EmailAddress,
                MobilePhone = studentModel.MobilePhone

            };

            List<Subject> listOfSubjects = new List<Subject>();

            foreach (SubjectModel subjectModel in studentModel.Subjects)
            {
                Subject subject = new Subject()
                {
                    Name = subjectModel.Name,
                    Credits = subjectModel.Credits,
                    Semestar = subjectModel.Semestar,
                    StudentId = subjectModel.StudentId
                };
                listOfSubjects.Add(subject);
            }


            student.Subjects = listOfSubjects;



            _studentRepository.Insert(student);

        }
    }
}
