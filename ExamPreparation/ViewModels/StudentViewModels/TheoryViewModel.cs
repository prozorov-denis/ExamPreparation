using DAL.Entities;
using ExamPreparation.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class TheoryViewModel : ViewModelBase
    {
        private ExamDbContext db;

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

        public TheoryViewModel(ExamDbContext db, int TopicId, Action showTopics, Action<object> showTasks) : base()
        {
            this.db = db;

            Topic topic = this.db.Topic.Find(TopicId);

            this.TopicId = TopicId;
            Title = topic.Title;

            try
            {
                theoryFilePath = Path.GetTempPath() + "tempFile.xps";
                File.WriteAllBytes(theoryFilePath, topic.Theory);
                TheoryFile = new XpsDocument(theoryFilePath, FileAccess.Read);
                Theory = TheoryFile.GetFixedDocumentSequence();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалосб загрузить файл с теорией. " + ex.Message);
            }
            

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
