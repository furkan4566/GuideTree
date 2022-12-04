using DataAccess.Abstarct;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSoftwareLangueDal : EfEntityRepositoryBase<SoftwareLangue, GuideTreeContext>, ISoftwareLangueDal
    {
        public SoftwareLangue GetLangueDetails(string url)
        {
            using (var context = new GuideTreeContext())
            {
                return context.SoftwareLangues.Where(i => i.Url == url).FirstOrDefault();
            }
        }

    }
}
