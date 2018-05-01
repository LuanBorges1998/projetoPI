using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class ContrarioRepository
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

        public List<contrario> GetAll()
        {
            return DataModel.contrario.ToList();
        }

        public contrario GetById(int id)
        {
            return DataModel.contrario.FirstOrDefault(x => x.id == id);
        }

        public void Salvar(contrario contrario)
        {
            DataModel.Entry(contrario).State = contrario.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            //DataModel.usuario.Add(usuario);
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.contrario.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}