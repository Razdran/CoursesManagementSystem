using System;
using CourseLab.Data;

namespace CourseLab.Data.UserManagement.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private UserManagementContext dbContext;

        public UnitOfWork(UserManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }

}
