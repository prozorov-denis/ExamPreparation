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
        MessagesRepository messagesRepository;
        ModulesRepository modulesRepository;
        PlansRepository plansRepository;
        ResultsRepository resultsRepository;
        SolutionsRepository solutionsRepository;
        StudentsRepository studentsRepository;
        TasksRepository tasksRepository;
        TeachersRepository teachersRepository;
        TheoryRepository theoryRepository;
        TopicsRepository topicsRepository;
        User_TypesRepository user_TypesRepository;
        UsersRepository usersRepository;
        ReportsRepository reportsRepository;

        public EFUnitOfWork()
        {
            db = new ExamPreparationDb();
        }

        public IRepository<Messages> IMessagesRepository
        {
            get
            {
                if (messagesRepository == null)
                    messagesRepository = new MessagesRepository(db);
                return messagesRepository;
            }
        }

        public IRepository<Modules> IModulesRepository
        {
            get
            {
                if (modulesRepository == null)
                    modulesRepository = new ModulesRepository(db);
                return modulesRepository;
            }
        }

        public IRepository<Plans> IPlansRepository
        {
            get
            {
                if (plansRepository == null)
                    plansRepository = new PlansRepository(db);
                return plansRepository;
            }
        }

        public IRepository<Results> IResultsRepository
        {
            get
            {
                if (resultsRepository == null)
                    resultsRepository = new ResultsRepository(db);
                return resultsRepository;
            }
        }

        public IRepository<Solutions> ISolutionsRepository
        {
            get
            {
                if (solutionsRepository == null)
                    solutionsRepository = new SolutionsRepository(db);
                return solutionsRepository;
            }
        }

        public IRepository<Students> IStudentsRepository
        {
            get
            {
                if (studentsRepository == null)
                    studentsRepository = new StudentsRepository(db);
                return studentsRepository;
            }
        }

        public IRepository<Tasks> ITasksRepository
        {
            get
            {
                if (tasksRepository == null)
                    tasksRepository = new TasksRepository(db);
                return tasksRepository;
            }
        }

        public IRepository<Teachers> ITeachersRepository
        {
            get
            {
                if (teachersRepository == null)
                    teachersRepository = new TeachersRepository(db);
                return teachersRepository;
            }
        }

        public IRepository<Theory> ITheoryRepository
        {
            get
            {
                if (theoryRepository == null)
                    theoryRepository = new TheoryRepository(db);
                return theoryRepository;
            }
        }

        public IRepository<Topics> ITopicsRepository
        {
            get
            {
                if (topicsRepository == null)
                    topicsRepository = new TopicsRepository(db);
                return topicsRepository;
            }
        }

        public IRepository<User_Types> IUser_TypesRepository
        {
            get
            {
                if (user_TypesRepository == null)
                    user_TypesRepository = new User_TypesRepository(db);
                return user_TypesRepository;
            }
        }

        public IRepository<Users> IUsersRepository
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }

        public IReportsRepository IReportsRepository
        {
            get
            {
                if (reportsRepository == null)
                    reportsRepository = new ReportsRepository(db);
                return reportsRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
