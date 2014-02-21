using OrionsBelt.Generic.Messages;
namespace OrionsBelt.Generic {

	public abstract class ResultItem {

		#region Fields

		protected string log;
		protected string name;
		protected string[] parameters = new string[]{};

		#endregion

		#region Instance Abstract Methods

		public virtual string Log() {
			return string.Format(log, parameters);
		}

		public virtual string[] Params {
			get { return parameters; }
		}

		public virtual string Name {
			get {
                if (!string.IsNullOrEmpty(name)) {
                    return name;
                }
                return this.GetType().Name;
            }
		}

        public virtual bool Ok {
            get { return true; }
        }

        public virtual string Log(IMessageParameterTranslator translator)
        {
            return string.Format(translator.Translate(Name), Params);
        }

		#endregion

    }
}
