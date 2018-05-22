using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class UsuarioRepository
    {
        private DataModel _DataModel;
        public DataModel DataModel {
            get {
                if (_DataModel == null)
                    _DataModel = new DataModel();
                return _DataModel;
            }
            set
            {
                _DataModel = value;
            }
        }

        public void Salvar(usuario usuario)
        {
            DataModel.Entry(usuario).State = usuario.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            //DataModel.usuario.Add(usuario);
            DataModel.SaveChanges();
        }

        public List<usuario> GetByName(String nome)
        {
            return DataModel.usuario.Where(user => user.login.Equals(nome)).ToList();
        }

        public usuario GetById(int id)
        {
            return DataModel.usuario.FirstOrDefault(m => m.id == id);
        }

        public List<usuario> GetAll()
        {
            return DataModel.usuario.ToList();
        }

        public List<usuario> GetSocio()
        {
            return DataModel.usuario.Where(x => x.perfil.tipo.Equals("SOCIO")).ToList();
        }

        public void Excluir(int id)
        {
            DataModel.usuario.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}