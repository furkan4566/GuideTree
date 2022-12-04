using Core.DataAccess;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface ISoftwareBranchDal:IEntityRepository<SoftwareBranch>
    {
        public List<SoftwareBranch> GetDetails();
    }
}
