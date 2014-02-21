using System;
using System.Web.UI;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Indicates where an object can be obtained
    /// </summary>
	public enum SourceType {

        /// <summary>
        /// Object obtained in the parent control 
        /// </summary>
		Parent,

        /// <summary>
        /// Object obtained via an Id in the Query String
        /// </summary>
		QueryString,

        /// <summary>
        /// Object obtained via an Id in the Form
        /// </summary>
		Form,

        /// <summary>
        /// Object obtained via the Items container
        /// </summary>
		Items,

        /// <summary>
        /// Object obtained via the Session container
        /// </summary>
		Session,

        /// <summary>
        /// Object obtained via the Cache container
        /// </summary>
		Cache,

        /// <summary>
        /// Object obtained via the Application container
        /// </summary>
		Application,

        /// <summary>
        /// A new object will be created
        /// </summary>
		New,

        /// <summary>
        /// A combo box will be available to choose the object
        /// </summary>
		Choice,

        /// <summary>
        /// Random object from the data source
        /// </summary>
		Random,

        /// <summary>
        /// Object based on the current day
        /// </summary>
		ByTheDay,

        /// <summary>
        /// Object obtained via the Context.User
        /// </summary>
        /// <remarks>
        /// To be used by the Principal related controls
        /// </remarks>
		ContextUser,

        /// <summary>
        /// No source set
        /// </summary>
		None
	};

}