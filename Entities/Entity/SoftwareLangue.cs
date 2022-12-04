using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class SoftwareLangue : IEntity
    {

        public int SoftwareLangueId { get; set; }
        public int SoftwareBranchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        //public List<SoftwareBranch> softwareBranchLangues { get; set; } entiytin in verileri barındırır.
        public SoftwareBranch SoftwareBranchs { get; set; }
    }
}
