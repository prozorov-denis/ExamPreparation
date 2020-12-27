using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private ExamDbContext db;

        public Student CurrentStudent { get; set; }

        private ViewModelBase currentStudyingVM;
        public ViewModelBase CurrentStudyingVM
        {
            get { return currentStudyingVM; }
            set
            {
                currentStudyingVM = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase currentChatViewModel;
        public ViewModelBase CurrentChatViewModel
        {
            get { return currentChatViewModel; }
            set
            {
                currentChatViewModel = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase currentPlanViewModel;
        public ViewModelBase CurrentPlanViewModel
        {
            get { return currentPlanViewModel; }
            set
            {
                currentPlanViewModel = value;
                OnPropertyChanged();
            }
        }

        public StatisticsViewModel CurrentStatisticsVM { get; set; }

        public StudentViewModel(Student student, ExamDbContext db)
        {
            this.db = db;
            CurrentStudent = student;
            CurrentStudyingVM = new TopicsViewModel(db, ShowTheory, ShowTasks);
            CurrentChatViewModel = new ChatViewModel(db, CurrentStudent.User, CurrentStudent.Teacher.User);
            CurrentStatisticsVM = new StatisticsViewModel(CurrentStudent, db);
            CurrentPlanViewModel = new PlanViewModel(CurrentStudent, db);
        }

        private void ShowThemes()
        {
            CurrentStudyingVM = new TopicsViewModel(db, ShowTheory, ShowTasks);
        }

        private void ShowTheory(object obj)
        {
            CurrentStudyingVM = new TheoryViewModel(db, Convert.ToInt32(obj), ShowThemes, ShowTasks);
        }


        private void ShowTasks(object obj)
        {
            CurrentStudyingVM = new TasksViewModel(db, Convert.ToInt32(obj), CurrentStudent.StudentId, ShowThemes, ShowTheory);
        }
    }
}
