﻿using NetDevChallange.Core.DataAccess.EntityFramework;
using NetDevChallange.DataAccess.Abstract;
using NetDevChallange.DataAccess.Concrete.EntityFramework.Contexts;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NetDevChallangeContext>, IUserDal
    {
    }
}
