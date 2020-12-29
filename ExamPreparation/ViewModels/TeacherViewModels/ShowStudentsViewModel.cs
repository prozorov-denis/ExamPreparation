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

        List<StudentModel> allStudents;
        List<StudentModel> students;
        public List<StudentModel> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        private Action<object> currentAction;

        public string CurrentActionTitle { get; set; }

        string searchString;
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                OnPropertyChanged();
            }
        }

        public ShowStudentsViewModel(Teacher teacher, ExamDbContext db, Action<object> CurrentAction, string CurrentActionTitle)
        {
            this.db = db;
            CurrentTeacher = teacher;
            currentAction = CurrentAction;
            this.CurrentActionTitle = CurrentActionTitle;

            searchString = "";

            Students = new List<StudentModel>();
            allStudents = new List<StudentModel>();

            try
            {
                var students = teacher.Student.ToList();

                if (students.Count > 0)
                    foreach (Student s in students)
                        allStudents.Add(new StudentModel(s));

                Students = allStudents;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка. " + ex.Message);
            }
            
        }

        private void findStudent()
        {
            if (SearchString.Length > 0)
                Students = allStudents.Where(st => st.FullName.Contains(SearchString)).ToList();
            else
                Students = allStudents;
        }

        public ICommand FindStudentCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    findStudent();
                });
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
