using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Task> Tasks { get; }
        IRepository<Topic> Topics { get; }
        IRepository<User> Users { get; }
        int Save();
    }
}
