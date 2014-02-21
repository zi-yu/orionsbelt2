using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceRankChangedMessage")]
	public class AllianceRankChangedMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceRankChangedMessage();
		}

        public override string Translate()
        {
            string param1 = Parameters[0];
            string param2 = Parameters[1];
            string param3 = LanguageTranslator.Translate(Parameters[2]);

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2, param3);
        }

		#endregion Overriden

    };
}
