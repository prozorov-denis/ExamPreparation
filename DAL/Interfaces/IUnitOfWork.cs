using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Messages> IMessagesRepository { get; }
        IRepository<Modules> IModulesRepository { get; }
        IRepository<Plans> IPlansRepository { get; }
        IRepository<Results> IResultsRepository { get; }
        IRepository<Solutions> ISolutionsRepository { get; }
        IRepository<Students> IStudentsRepository { get; }
        IRepository<Tasks> ITasksRepository { get; }
        IRepository<Teachers> ITeachersRepository { get; }
        IRepository<Theory> ITheoryRepository { get; }
        IRepository<Topics> ITopicsRepository { get; }
        IRepository<User_Types> IUser_TypesRepository { get; }
        IRepository<Users> IUsersRepository { get; }
        IReportsRepository IReportsRepository { get; }
        int Save();
    }
}
