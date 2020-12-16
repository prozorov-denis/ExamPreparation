using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ExamPreparationDb db;
        MessageRepository messageRepository;
        ModuleRepository moduleRepository;
        ResultRepository resultRepository;
        StudentRepository studentRepository;
        TaskRepository taskRepository;
        TeacherRepository teacherRepository;
        TopicRepository topicRepository;
        User_TypeRepository user_TypeRepository;
        UserRepository userRepository;
        ReportsRepository reportRepository;

        public EFUnitOfWork()
        {
            db = new ExamPreparationDb();
        }

        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }

        public IRepository<Module> Modules
        {
            get
            {
                if (moduleRepository == null)
                    moduleRepository = new ModuleRepository(db);
                return moduleRepository;
            }
        }   

        public IRepository<Result> Results
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(db);
                return resultRepository;
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }
        }

        public IRepository<Entities.Task> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(db);
                return teacherRepository;
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new TopicRepository(db);
                return topicRepository;
            }
        }

        public IRepository<User_Type> User_Types
        {
            get
            {
                if (user_TypeRepository == null)
                    user_TypeRepository = new User_TypeRepository(db);
                return user_TypeRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportsRepository(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
