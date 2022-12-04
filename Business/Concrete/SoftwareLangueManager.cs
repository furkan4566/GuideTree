using Business.Abstarct;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SoftwareLangueManager : ISoftwareLangueService
    {
        private ISoftwareLangueDal _softwarelangue;
        public SoftwareLangueManager(ISoftwareLangueDal softwarelangue)
        {
            _softwarelangue = softwarelangue;
        }
        public void Create(SoftwareLangue entity)
        {
            _softwarelangue.Create(entity);
        }

        public void Delete(SoftwareLangue entity)
        {
            _softwarelangue.Delete(entity);
        }

        public List<SoftwareLangue> GetAll()
        {
            return _softwarelangue.GetAll();
        }

        public SoftwareLangue GetById(int id)
        {
            return _softwarelangue.GetById(id);
        }

        public void Update(SoftwareLangue entity)
        {
            _softwarelangue.Update(entity);
        }

        public string ErrorMassage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Validation(SoftwareLangue entity)
        {
            throw new NotImplementedException();
        }

        public SoftwareLangue GetLangueDetails(string url)
        {
            return _softwarelangue.GetLangueDetails(url);
        }
    }
}
