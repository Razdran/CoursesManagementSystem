using System;
namespace CourseLabs.Data.UserManagement.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
