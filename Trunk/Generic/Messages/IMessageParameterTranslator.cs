namespace OrionsBelt.Generic.Messages {
	public interface IMessageParameterTranslator {
		string Translate(string arg);
        string CurrentLanguage { get;}
	}
}
