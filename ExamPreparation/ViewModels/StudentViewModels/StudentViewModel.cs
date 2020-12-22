using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;

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

        public StudentViewModel(Student student, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            CurrentStudent = student;
            CurrentStudyingVM = new TopicsViewModel(unitOfWork, ShowTheory, ShowTasks);
        }

        private void ShowThemes()
        {
            CurrentStudyingVM = new TopicsViewModel(unitOfWork, ShowTheory, ShowTasks);
        }

        private void ShowTheory(object obj)
        {
            CurrentStudyingVM = new TheoryViewModel(unitOfWork, Convert.ToInt32(obj), ShowThemes, ShowTasks);
        }


        private void ShowTasks(object obj)
        {
            CurrentStudyingVM = new TasksViewModel(unitOfWork, Convert.ToInt32(obj), ShowThemes, ShowTheory);
        }
    }
}
