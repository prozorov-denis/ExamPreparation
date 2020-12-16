using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace ExamPreparation.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public FixedDocumentSequence Text { get; set; }
        public bool IsDone { get; set; }

        public TaskModel(Task task)
        {
            TaskId = task.TaskId;
            Title = "Задание " + TaskId;
            Text = GetFixedDocumentSequence(task.Text);
        }

        private FixedDocumentSequence GetFixedDocumentSequence(byte[] xpsBytes)
        {
            Uri packageUri;
            XpsDocument xpsDocument = null;

            using (MemoryStream xpsStream = new MemoryStream(xpsBytes))
            {
                using (Package package = Package.Open(xpsStream))
                {
                    packageUri = new Uri("memorystream://myXps.xps");

                    try
                    {
                        PackageStore.AddPackage(packageUri, package);
                        xpsDocument = new XpsDocument(package, CompressionOption.Maximum, packageUri.AbsoluteUri);

                        return xpsDocument.GetFixedDocumentSequence();
                    }
                    finally
                    {
                        if (xpsDocument != null)
                        {
                            xpsDocument.Close();
                        }
                        PackageStore.RemovePackage(packageUri);
                    }
                }
            }
        }
    }
}
