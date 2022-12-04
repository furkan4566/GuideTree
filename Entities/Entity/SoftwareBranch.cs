using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class SoftwareBranch : IEntity
    {
        public int SoftwareBranchId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public SoftwareLangue SoftwareLangues { get; set; }

    }
}
