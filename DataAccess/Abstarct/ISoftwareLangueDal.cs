using Core.DataAccess;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface ISoftwareLangueDal:IEntityRepository<SoftwareLangue>
    {
         SoftwareLangue GetLangueDetails(string url);
    }
}
