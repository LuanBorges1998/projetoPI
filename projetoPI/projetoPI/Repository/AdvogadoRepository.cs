using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class AdvogadoRepository
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

        public void Salvar(advogado advogado)
        {
            DataModel.Entry(advogado).State = advogado.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }

        public advogado GetSocio(int id)
        {
            advogado adv = GetByIdUsuario(id);
            return DataModel.advogado.FirstOrDefault(x => x.id == adv.id_socio);
        }

        public advogado GetByIdUsuario(int id)
        {
            return DataModel.advogado.FirstOrDefault(x => x.id_usuario == id);
        }

        public advogado GetById(int id)
        {
            return DataModel.advogado.FirstOrDefault(x => x.id == id);
        }

        public List<advogado> GetAllSocios()
        {
            return DataModel.advogado.Where(x => x.usuario.id_perfil == 3).ToList();
        }
    }
}