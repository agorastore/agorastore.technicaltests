using Agorastore.TechnicalTests.API.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgoraStoreTest.Business.ConfigurateursDePrix
{
    public class configurateurDePrix : IConfigurateurDePrix
    {
        private decimal _tauxComission = 0.33m;

        public decimal GetTauxcommission()
        {
            return _tauxComission;
        }

    }
}
