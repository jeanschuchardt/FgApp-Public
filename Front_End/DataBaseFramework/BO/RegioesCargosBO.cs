﻿using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class RegioesCargosBO
    {
        public string ConnectionString { get; set; }

        public RegioesCargosBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<RegioesCargos> GetAllRegioesCargos()
        {
            return new RegioesCargosDAO(ConnectionString).GetAllRegioesCargos();
        }

        public List<RegioesCargos> GetDistribuicaoFuncoes(RegioesCargos regioesCargos)
        {
            return new RegioesCargosDAO(ConnectionString).GetDistribuicaoFuncoes(regioesCargos);
        }

        public List<RegioesCargos> GetServidoresPorPartido(RegioesCargos regioesCargos)
        {
            return new RegioesCargosDAO(ConnectionString).GetServidoresPorPartido(regioesCargos);
        }
    }
}