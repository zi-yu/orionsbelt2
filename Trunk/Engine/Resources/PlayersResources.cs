using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrionsBelt.Engine.Resources
{
    public class PlayersResources
    {
        #region private fields

        private int id;
        private int cryptium=0;
        private int argon=0;
        private int radon=0;
        private int astatine=0;
        private int prismal=0;
        private int energy=0;
        private int serium=0;
        private int mithril=0;
        private int gold=0;
        private int titanium=0;
        private int uranium=0;
        private int elk=0;
        private int protol=0;
        private int queueSpace=0;
        private int productionSpace = 0;
        private string name;

        #endregion private fields

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Cryptium
        {
            get { return cryptium; }
            set { cryptium = value; }
        }

        public int Argon
        {
            get { return argon; }
            set { argon = value; }
        }

        public int Radon
        {
            get { return radon; }
            set { radon = value; }
        }

        public int Astatine
        {
            get { return astatine; }
            set { astatine = value; }
        }

        public int Prismal
        {
            get { return prismal; }
            set { prismal = value; }
        }

        public int Energy
        {
            get { return energy; }
            set { energy = value; }
        }

        public int Serium
        {
            get { return serium; }
            set { serium = value; }
        }

        public int Mithril
        {
            get { return mithril; }
            set { mithril = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int Titanium
        {
            get { return titanium; }
            set { titanium = value; }
        }

        public int Uranium
        {
            get { return uranium; }
            set { uranium = value; }
        }

        public int Elk
        {
            get { return elk; }
            set { elk = value; }
        }

        public int Protol
        {
            get { return protol; }
            set { protol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int QueueSpace
        {
            get { return queueSpace; }
            set { queueSpace = value; }
        }

        public int ProductionSpace
        {
            get { return productionSpace; }
            set { productionSpace = value; }
        }

        #endregion Properties

        #region Ctors

        public PlayersResources(int id, string name, string resourceString)
        {
            this.id = id;
            this.name = name;

            Dictionary<string, int> data = new Dictionary<string, int>();
            string[] separate = resourceString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string res in separate)
            {
                string[] finalData = res.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.ContainsKey(finalData[0]))
                {
                    data[finalData[0]] += Convert.ToInt32(finalData[1]);
                }
                else
                {
                    data.Add(finalData[0], Convert.ToInt32(finalData[1]));
                }
            }

            foreach (KeyValuePair<string, int> pair in data)
            {
                PropertyInfo pi = GetType().GetProperty(pair.Key);
                if(null != pi)
                {
                  pi.SetValue(this,pair.Value,null);  
                }
            }
            
        }

        #endregion Ctors



    }
}
