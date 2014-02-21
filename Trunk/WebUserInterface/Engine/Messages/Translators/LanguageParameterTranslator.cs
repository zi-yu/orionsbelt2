using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	public class LanguageParameterTranslator : IMessageParameterTranslator {

		#region Fields

		private static readonly LanguageParameterTranslator languageTranslator = new LanguageParameterTranslator();

		#endregion Fields

		#region Properties

		public static IMessageParameterTranslator Instance {
			get { return languageTranslator; }
		}

		#endregion Properties

		#region IMessageParameterTranslator Members

		public string Translate(string arg) {
			return LanguageManager.Instance.Get(arg);
		}

        public string CurrentLanguage {
            get { return LanguageManager.CurrentLanguage; }
        }

		#endregion IMessageParameterTranslator Members

		#region Constructor

		private LanguageParameterTranslator(){}
		 
		#endregion Constructor
	}
}
