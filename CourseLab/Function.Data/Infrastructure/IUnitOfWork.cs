using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
