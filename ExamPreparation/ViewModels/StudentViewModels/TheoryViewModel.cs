using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class TheoryViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;

        public int TopicId { get; set; }

        public string Title { get; set; }

        private string theoryFilePath;
        private XpsDocument theoryFile;
        public XpsDocument TheoryFile
        {
            get { return theoryFile;  }
            set
            {
                theoryFile = value;
                OnPropertyChanged();
            }
        }

        private IDocumentPaginatorSource theory;
        public IDocumentPaginatorSource Theory
        {
            get { return theory; }
            set { theory = value; OnPropertyChanged(); }
        }

        private Action showTopics;
        private Action<object> showTasks;

        public TheoryViewModel(UnitOfWork unitOfWork, int TopicId, Action showTopics, Action<object> showTasks) : base()
        {
            this.unitOfWork = unitOfWork;

            Topic topic = this.unitOfWork.Topics.GetItem(TopicId);

            this.TopicId = TopicId;
            Title = topic.Title;

            theoryFilePath = Path.GetTempPath() + "tempFile.xps";
            File.WriteAllBytes(theoryFilePath, topic.Theory);
            TheoryFile = new XpsDocument(theoryFilePath, FileAccess.Read);
            Theory = TheoryFile.GetFixedDocumentSequence();

            this.showTopics = showTopics;
            this.showTasks = showTasks;
        }

        public ICommand ShowTopicsCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showTopics.Invoke();
                    TheoryFile.Close();
                    if (File.Exists(theoryFilePath))
                        File.Delete(theoryFilePath);
                });
            }
        }

        public ICommand ShowTasksCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showTasks.Invoke(obj);
                    TheoryFile.Close();
                    if (File.Exists(theoryFilePath))
                        File.Delete(theoryFilePath);
                });
            }
        }
    }
}
