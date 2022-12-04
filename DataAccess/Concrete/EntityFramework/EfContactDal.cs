using DataAccess.Abstarct;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, GuideTreeContext>, IContactDal
    {

    }
}
