using Agorastore.TechnicalTests.API.Business.MoteursCalcul;
using Agorastore.TechnicalTests.API.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agorastore.TechnicalTests.API.Business.MoteursCalcul
{
    public class MoteurDeCalcul : IMoteurCalcul
    {
        IConfigurateurDePrix _configurateurDePrix;
        public MoteurDeCalcul(IConfigurateurDePrix configurateurDePrix)
        {
            _configurateurDePrix = configurateurDePrix;
        }
        public decimal GetPrixVente (decimal prixInitial)
        {
            decimal tauxComission = _configurateurDePrix.GetTauxcommission();
            decimal prixVenteHT = prixInitial + prixInitial * tauxComission;

            return prixVenteHT;
        }
    }
}
