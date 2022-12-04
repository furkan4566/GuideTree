using DataAccess.Abstarct;
using Entities.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSoftwareBranchDal : EfEntityRepositoryBase<SoftwareBranch, GuideTreeContext>, ISoftwareBranchDal
    {
        public List<SoftwareBranch> GetDetails()
        {
            using (var context = new GuideTreeContext())
            {
                //var result = from sb in context.SoftwareBranches
                //             join sl in context.SoftwareLangues
                //             on sb.SoftwareBranchId equals sl.SoftwareBranchId
                //             select new
                //             {
                //                 sb.Name,
                //                 sb.SoftwareBranchId,
                //                 sl.SoftwareLangueId,
                //                 sl.Url
                //             };
                return context.SoftwareBranches.Where(s => s.SoftwareBranchId == s.SoftwareLangues.SoftwareBranchId).ToList();
                //var result = context.SoftwareBranches.Join(context.SoftwareLangues, sb => sb.SoftwareBranchId,
                //              sl => sl.SoftwareBranchId,
                //              (sb, sl) => new
                //              {
                //                  sb.SoftwareBranchId,
                //                  sl.SoftwareLangueId,
                //                  sb.Name,
                //                  sl.Url
                //              });
                //return result;
            }
        }
    }
}
