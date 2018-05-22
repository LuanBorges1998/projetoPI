using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class PerfilRepository
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

        public perfil GetPerfil(String tipo)
        {
            return DataModel.perfil.FirstOrDefault(x => x.tipo.Equals(tipo));
        }

        public List<perfil> GetAll()
        {
            return DataModel.perfil.ToList();
        }
    }
}