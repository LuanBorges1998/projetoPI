using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class DocumentoRepository
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

        public List<documento> GetAll()
        {
            return DataModel.documento.ToList();
        }

        public documento GetById(int id)
        {
            return DataModel.documento.FirstOrDefault(x => x.id == id);
        }

        public void Salvar(documento documento)
        {
            DataModel.Entry(documento).State = documento.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            //DataModel.usuario.Add(usuario);
            DataModel.SaveChanges();
        }

        public void Save()
        {
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.documento.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}