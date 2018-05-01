using projetoPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoPI.Repository
{
    public class AgendamentoRepository
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

        public List<agendamento> GetAll()
        {
            return DataModel.agendamento.ToList();
        }

        public agendamento GetById(int id)
        {
            return DataModel.agendamento.FirstOrDefault(x => x.id == id);
        }

        public List<agendamento> GetDeUmUsuario(int id)
        {
            return DataModel.agendamento.Where(x => x.id_usuario == id).ToList();
        }

        public void Salvar(agendamento agendamento)
        {
            DataModel.Entry(agendamento).State = agendamento.id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }

        public void Excluir(int id)
        {
            DataModel.agendamento.Remove(GetById(id));
            DataModel.SaveChanges();
        }
    }
}