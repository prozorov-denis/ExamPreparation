using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }

        public StudentModel(Student student)
        {
            StudentId = student.StudentId;
            FullName = student.User.Surname + " " + student.User.Name + " " + student.User.Patronymic;
            Login = student.User.Login;
        }
    }
}
