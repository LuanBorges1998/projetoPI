using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class ClienteRepository
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

        public List<cliente> GetAll()
        {
            return DataModel.cliente.ToList();
        }

        public cliente GetById(int id)
        {
            return DataModel.cliente.FirstOrDefault(x => x.id == id);
        }

        public void Salvar(cliente cliente)
        {
            DataModel.Entry(cliente).State = cliente.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            //DataModel.usuario.Add(usuario);
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.cliente.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}