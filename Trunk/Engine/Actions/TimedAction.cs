using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.Engine.Common;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Engine.Actions {
    
    /// <summary>
    /// Represented a delayed action
    /// </summary>
    public abstract class TimedAction : ITimedAction, DesignPatterns.IFactory {

        #region Ctor

        public TimedAction()
        {
        }

        public TimedAction(TimedActionStorage storage)
        {
            this.storage = storage;
            ActionConversion.SetAction(this, storage);
        }

        #endregion Ctor

        #region ITimedAction Properties

        private int startTick;
        public int StartTick {
            get { return startTick; }
            set {
                Touch();
                startTick = value; 
            }
        }

        private int endTick;
        public int EndTick {
            get { return endTick; }
            set {
                Touch();
                endTick = value; 
            }
        }

        private int interval;
        public virtual int Interval {
            get { return interval; }
            set {
                Touch();
                interval = value; 
            }
        }

        public virtual bool IsPersistable {
            get { return !(Occurrence == Occurrence.AutoRepeat && Visibility == Visibility.Private); }
        }

        public abstract Occurrence Occurrence { get; }

        public abstract Visibility Visibility { get; }

        public virtual int CurrentTick {
            get { return Clock.Instance.Tick; }
        }

        public virtual bool Started {
            get { return StartTick > CurrentTick; }
        }

        private bool ended = false;
        public virtual bool Ended {
            get { return ended; }
            set { ended = value; }
        }

        #endregion ITimedAction Properties

        #region ITimedAction Methods

        public void Start()
        {
            StartTick = CurrentTick;
            EndTick = StartTick + Interval;
        }

        public void Start(int delay)
        {
            Interval = delay;
            Start();
        }

        protected virtual void Restart()
        {
        	Interval = EndTick + (EndTick-StartTick);
            StartTick = EndTick;
            EndTick = Interval;
        }

        public virtual void ForceEnd(bool processAction)
        {
            ProcessAction(processAction);
        }

        #endregion

        #region IAction Properties

        public virtual string Name {
            get { return GetType().Name; }
        }

        private string data;
        public virtual string Data {
            get { return data; }
            set {
                Touch();
                data = value;
            }
        }

        #endregion IAction Properties

        #region IAction Members

        public void Process()
        {
            try {

                Ended = Occurrence != Occurrence.AutoRepeat;
                ProcessAction(false);

                if (!Ended) {
                    Restart();
                }

            } catch (Exception ex) {
                ExceptionLogger.Log(ex);
                if (Server.IsInTests) {
                    throw;
                }
            }
        }

        #endregion

        #region Abstract Members

        protected abstract void ProcessAction(bool forcedEnd);

        #endregion Abstract Members

        #region IFactory Members

        public object create(object args)
        {
            return Activator.CreateInstance(GetType());
        }

        #endregion

        #region IBackToStorage Implementation

        private TimedActionStorage storage;
        public TimedActionStorage Storage {
            get {
                if (storage == null) {
                    throw new EngineException("Storage is null");
                }
                return storage;
            }
            set { storage = value; }
        }

        public void PrepareStorage()
        {
            if (this.storage == null) {
                this.storage = ActionConversion.ConvertActionToStorage(this);
            }
        }

        public void UpdateStorage()
        {
            ActionConversion.SetStorage(storage, this);
        }

        public void Touch()
        {
            IsDirty = true;
        }

        private bool dirty = false;
        public bool IsDirty {
            get { return dirty; }
            set { dirty = value; }
        }

        #endregion IBackToStorage Implementation

    };
}
