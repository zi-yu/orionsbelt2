using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Put rare items in markets
    /// </summary>
    public class MarketReinforce : AutoRepeteAction {

        private IList<string> resources = new List<string>(5);
        #region Ctor 

        public MarketReinforce()
        {
			Start(1);
            resources.Add("Astatine");
            resources.Add("Argon");
            resources.Add("Cryptium");
            resources.Add("Prismal");
            resources.Add("Radon");
		}

        #endregion Ctor 

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void Restart()
        {
            Random rand = new Random();
            Interval = rand.Next(72, 145);
            StartTick = EndTick;
            EndTick += Interval;
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Random rand = new Random();
            using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance())
            {
                IList<Market> items = persistance.Select();
                
                for(int iter = 0; iter < items.Count; ++iter)
                {
                    bool putNew = true;
                    foreach (Product product in items[iter].Products)
                    {
                        if(product.Type == "Rare")
                        {
                            putNew = false;
                            break;
                        }
                    }
                    if(putNew)
                    {
                        using (IProductPersistance persistance2 = Persistance.Instance.GetProductPersistance(persistance))
                        {
                            Product prod = persistance2.Create();
                            prod.Name = resources[rand.Next(0, resources.Count)];
                            prod.Price = 4;
                            prod.Quantity = items[iter].Level*1000;
                            prod.Market = items[iter];
                            prod.Type = "Rare";
                            
                            persistance2.Update(prod);
                        }
                    }         
                }
                persistance.Flush();
            }
            
        }

        #endregion Base Implementation

    };

}
