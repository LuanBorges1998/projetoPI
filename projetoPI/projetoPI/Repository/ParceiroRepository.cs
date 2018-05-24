using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class ParceiroRepository
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

        public List<parceiro> GetAll()
        {
            return DataModel.parceiro.ToList();
        }

        public parceiro GetById(int id)
        {
            return DataModel.parceiro.FirstOrDefault(x => x.id == id);
        }

        public void Salvar(parceiro parceiro)
        {
            DataModel.Entry(parceiro).State = parceiro.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            //DataModel.usuario.Add(usuario);
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.parceiro.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}