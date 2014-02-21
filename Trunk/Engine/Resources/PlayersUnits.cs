using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Resources
{
    public class PlayersUnits
    {
        #region private fields

        private int id;
        private int fleetValue=0;
        private int vector = 0;
        private int raptor = 0;
        private int spider = 0;
        private int heavySeeker = 0;
        private int hiveProtector = 0;
        private int taurus = 0;
        private int eagle = 0;
        private int toxic = 0;
        private int darkRain = 0;
        private int stinger = 0;
        private int bozer = 0;
        private int blinker = 0;
        private int panther = 0;
        private int queen = 0;
        private int rain = 0;
        private int samurai = 0;
        private int darkTaurus = 0;
        private int seeker = 0;
        private int worm = 0;
        private int pretorian = 0;
        private int hiveKing = 0;
        private int kamikaze = 0;
        private int nova = 0;
        private int anubis = 0;
        private int blackWidow = 0;
        private int crusader = 0;
        private int driller = 0;
        private int interceptor = 0;
        private int fenix = 0;
        private int scarab = 0;
        private int doomer = 0;
        private int darkCrusader = 0;
        private int kahuna = 0;
        private int destroyer = 0;
        private int battleMoon = 0;
        private int krill = 0;
        private string name;

        #endregion private fields

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int FleetValue
        {
            get { return fleetValue; }
            set { fleetValue = value; }
        }

        public int Vector
        {
            get { return vector; }
            set { vector = value; }
        }

        public int Raptor
        {
            get { return raptor; }
            set { raptor = value; }
        }

        public int Spider
        {
            get { return spider; }
            set { spider = value; }
        }

        public int HeavySeeker
        {
            get { return heavySeeker; }
            set { heavySeeker = value; }
        }

        public int HiveProtector
        {
            get { return hiveProtector; }
            set { hiveProtector = value; }
        }

        public int Taurus
        {
            get { return taurus; }
            set { taurus = value; }
        }

        public int Eagle
        {
            get { return eagle; }
            set { eagle = value; }
        }

        public int Toxic
        {
            get { return toxic; }
            set { toxic = value; }
        }

        public int DarkRain
        {
            get { return darkRain; }
            set { darkRain = value; }
        }

        public int Stinger
        {
            get { return stinger; }
            set { stinger = value; }
        }

        public int Bozer
        {
            get { return bozer; }
            set { bozer = value; }
        }

        public int Blinker
        {
            get { return blinker; }
            set { blinker = value; }
        }

        public int Panther
        {
            get { return panther; }
            set { panther = value; }
        }

        public int Queen
        {
            get { return queen; }
            set { queen = value; }
        }

        public int Rain
        {
            get { return rain; }
            set { rain = value; }
        }

        public int Samurai
        {
            get { return samurai; }
            set { samurai = value; }
        }

        public int DarkTaurus
        {
            get { return darkTaurus; }
            set { darkTaurus = value; }
        }

        public int Seeker
        {
            get { return seeker; }
            set { seeker = value; }
        }

        public int Worm
        {
            get { return worm; }
            set { worm = value; }
        }

        public int Pretorian
        {
            get { return pretorian; }
            set { pretorian = value; }
        }

        public int HiveKing
        {
            get { return hiveKing; }
            set { hiveKing = value; }
        }

        public int Kamikaze
        {
            get { return kamikaze; }
            set { kamikaze = value; }
        }

        public int Nova
        {
            get { return nova; }
            set { nova = value; }
        }

        public int Anubis
        {
            get { return anubis; }
            set { anubis = value; }
        }

        public int BlackWidow
        {
            get { return blackWidow; }
            set { blackWidow = value; }
        }

        public int Crusader
        {
            get { return crusader; }
            set { crusader = value; }
        }

        public int Driller
        {
            get { return driller; }
            set { driller = value; }
        }

        public int Interceptor
        {
            get { return interceptor; }
            set { interceptor = value; }
        }

        public int Fenix
        {
            get { return fenix; }
            set { fenix = value; }
        }

        public int Scarab
        {
            get { return scarab; }
            set { scarab = value; }
        }

        public int Doomer
        {
            get { return doomer; }
            set { doomer = value; }
        }

        public int DarkCrusader
        {
            get { return darkCrusader; }
            set { darkCrusader = value; }
        }

        public int Kahuna
        {
            get { return kahuna; }
            set { kahuna = value; }
        }

        public int Destroyer
        {
            get { return destroyer; }
            set { destroyer = value; }
        }

        public int BattleMoon
        {
            get { return battleMoon; }
            set { battleMoon = value; }
        }

        public int Krill
        {
            get { return krill; }
            set { krill = value; }
        }

        #endregion Properties

        #region Ctors

        public PlayersUnits(int id, string name)
        {
            Id = id;
            Name = name;
 
        }

        #endregion Ctors

        public void AddUnits(Fleet fleet)
        {
            FleetInfo info = new FleetInfo(fleet);
            fleetValue += info.FleetValue;
            foreach (KeyValuePair<string, IFleetElement> unit in info.Units)
            {
                if(null == GetType().GetProperty(unit.Value.Name))
                {
                    continue;
                }
                int field = Convert.ToInt32(GetType().GetProperty(unit.Value.Name).GetValue(this,null)) + unit.Value.Quantity;
                GetType().GetProperty(unit.Value.Name).SetValue(this, field, null);
            }
        }
    }
}
