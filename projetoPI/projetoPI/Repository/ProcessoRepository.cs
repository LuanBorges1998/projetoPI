using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class ProcessoRepository
    {
        private DataModel _DataModel;
        public DataModel DataModel
        {
            get
            {
                if (_DataModel == null)
                    _DataModel = new DataModel();
                return _DataModel;
            }
            set
            {
                _DataModel = value;
            }
        }

        public List<processo> GetAll()
        {
            return DataModel.processo.ToList();
        }

        public processo GetById(int id)
        {
            return DataModel.processo.FirstOrDefault(x => x.id == id);
        }

        public void Salvar(processo processo)
        {
            DataModel.Entry(processo).State = processo.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.processo.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}