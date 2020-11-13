using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Message> Messages { get; }
        IRepository<Module> Modules { get; }
        IRepository<Result> Results { get; }
        IRepository<Student> Students { get; }
        IRepository<Entities.Task> Tasks { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Topic> Topics { get; }
        IRepository<User_Type> User_Types { get; }
        IRepository<User> Users { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
