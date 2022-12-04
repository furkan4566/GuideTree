using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ISoftwareLangueService
    {
        SoftwareLangue GetById(int id);
        List<SoftwareLangue> GetAll();
        void Create(SoftwareLangue entity);
        void Update(SoftwareLangue entity);
        void Delete(SoftwareLangue entity);
        SoftwareLangue GetLangueDetails(string url);
    }
}
