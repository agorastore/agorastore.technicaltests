using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agorastore.TechnicalTests.API.Business.Interfaces;

namespace Agorastore.TechnicalTests.API.Business.ConfigurateursDePrix
{
    public class ConfigurateurDePrix2 : IConfigurateurDePrix
    {
        private decimal _tauxComission = 0.03m;

        public decimal GetTauxcommission()
        {
            return _tauxComission;
        }
    }
}
