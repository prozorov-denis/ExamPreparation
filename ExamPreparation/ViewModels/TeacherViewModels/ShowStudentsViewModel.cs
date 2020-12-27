using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels.TeacherViewModels
{
    public class ShowStudentsViewModel : ViewModelBase
    {
        ExamDbContext db;

        public Teacher CurrentTeacher { get; set; }

        public List<StudentModel> Students { get; set; }

        private Action<object> currentAction;

        public string CurrentActionTitle { get; set; }

        public ShowStudentsViewModel(Teacher teacher, ExamDbContext db, Action<object> CurrentAction, string CurrentActionTitle)
        {
            this.db = db;
            CurrentTeacher = teacher;
            currentAction = CurrentAction;
            this.CurrentActionTitle = CurrentActionTitle;

            Students = new List<StudentModel>();

            try
            {
                var students = teacher.Student.ToList();

                if (students.Count > 0)
                    foreach (Student s in students)
                        Students.Add(new StudentModel(s));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка. " + ex.Message);
            }
            
        }

        public ICommand CurrentActionCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    currentAction.Invoke(obj);
                });
            }
        }
    }
}
