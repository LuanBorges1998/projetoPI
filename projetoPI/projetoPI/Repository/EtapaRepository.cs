using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class EtapaRepository
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

        public void Salvar(etapa etapa)
        {
            DataModel.Entry(etapa).State = etapa.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.etapa.Remove(GetById(id));
            DataModel.SaveChanges();
        }

        public etapa GetById(int id)
        {
            return DataModel.etapa.FirstOrDefault(x => x.id == id);
        }

        public List<etapa> GetByIdProcesso(int id)
        {
            return DataModel.etapa.Where(x => x.id_processo == id).ToList();
        }
    }
}