using System;
using System.Collections.Generic;
using DesignPatterns;

namespace OrionsBelt.Generic.Messages {
	public interface IMessage : IFactory  {

		/// <summary>
		/// Category of the message
		/// </summary>
		Category Category { get; }

		/// <summary>
		/// Sub Category of the message
		/// </summary>
		string SubCategory { get; }

		/// <summary>
		/// Parameters of the message
		/// </summary>
		List<string> Parameters { get; set; }

		/// <summary>
		/// Date when the message was created
		/// </summary>
		DateTime Date { get; set; }

		/// <summary>
		/// Id of the Owner of the message
		/// </summary>
		int OwnerId { get; set; }

		/// <summary>
		/// Extended Information
		/// </summary>
		string Extended { get; set; }

        /// <summary>
        /// When this message expires
        /// </summary>
        int TickDeadline { get; set;}

		/// <summary>
		/// Translates a battle coordinate
		/// </summary>
		IMessageParameterTranslator CoordinateTranslator{ set; }

		/// <summary>
		/// Translates a I18n token
		/// </summary>
		IMessageParameterTranslator LanguageTranslator { set; }

		
		/// <summary>
		/// Translates a battle position
		/// </summary>
		IMessageParameterTranslator PositionTranslator { set;}

		/// <summary>
		/// Translates the message
		/// </summary>
		string Translate();

        /// <summary>
        /// The importance level
        /// </summary>
        MessageImportance Importance { get;}

		/// <summary>
		/// Type of the message
		/// </summary>
		MessageType MessageType { get;}

	}
}
