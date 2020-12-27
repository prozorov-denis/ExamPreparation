using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.ViewModels.TeacherViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        ExamDbContext db;

        public Teacher CurrentTeacher { get; set; }

        private ViewModelBase currentChatVM;
        public ViewModelBase CurrentChatVM
        {
            get { return currentChatVM; }
            set
            {
                currentChatVM = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase currentStatisticsVM;
        public ViewModelBase CurrentStatisticsVM
        {
            get { return currentStatisticsVM; }
            set
            {
                currentStatisticsVM = value;
                OnPropertyChanged();
            }
        }

        public TeacherViewModel(Teacher teacher, ExamDbContext db)
        {
            this.db = db;
            CurrentTeacher = teacher;

            CurrentChatVM = new ShowStudentsViewModel(CurrentTeacher, db, ShowChat, "Открыть чат");
            CurrentStatisticsVM = new ShowStudentsViewModel(CurrentTeacher, db, ShowStatistics, "Статистика");
        }

        private void ShowChat(object obj)
        {
            Student currentStudent = db.Student.Find(Convert.ToInt32(obj));
            if (currentStudent != null)
                CurrentChatVM = new ChatViewModel(db, CurrentTeacher.User, currentStudent.User, ShowChatStudents);
        }

        private void ShowStatistics(object obj)
        {
            Student currentStudent = db.Student.Find(Convert.ToInt32(obj));
            if (currentStudent != null)
                CurrentStatisticsVM = new StatisticsViewModel(currentStudent, db, true, ShowStatisticsStudents);
        }

        private void ShowChatStudents()
        {
            CurrentChatVM = new ShowStudentsViewModel(CurrentTeacher, db, ShowChat, "Открыть чат");
        }

        private void ShowStatisticsStudents()
        {
            CurrentStatisticsVM = new ShowStudentsViewModel(CurrentTeacher, db, ShowStatistics, "Статистика");
        }
    }
}
