namespace OrionsBelt.BattleCore.Translate {
	internal interface ITranslate {
		/// <summary>
		/// Translates the passed move
		/// </summary>
		/// <param name="move">Move to translate</param>
		/// <returns>Translated move</returns>
		string TranslateToSpecific(string move);

		/// <summary>
		/// Translates the passed move to store in the database
		/// </summary>
		/// <param name="move">Move to translate</param>
		/// <returns>Translated move</returns>
		string TranslateToBase( string move );
	}
}
