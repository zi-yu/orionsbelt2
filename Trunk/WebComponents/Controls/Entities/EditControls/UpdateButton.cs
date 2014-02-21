
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Starts an entity update action
    /// </summary>
    /// <remarks>
    /// This control has to be child of an IEntityEditor
    /// </remarks>
	public class UpdateButton : Button {

		#region Events

		/// <summary>
        /// Triggred event when the update process succeeds
        /// </summary>
        public event EventHandler Success;
		
		/// <summary>
        /// Triggred event when the update process fails
        /// </summary>
        public event EventHandler Failure;

		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
        protected override void OnInit(EventArgs args)
        {
			if (string.IsNullOrEmpty(Text))
            {
                Text = "Update";
            }
            base.OnInit(args);
        }

		/// <summary>
        /// The click event will start the update cycle
        /// </summary>
        /// <param name="args">Event arguments</param>
        protected override void OnClick(EventArgs args)
        {
            base.OnClick(args);

            IEntityEditor parent = Parent as IEntityEditor;
            if (parent == null) {
                throw new Exception("Parent it's not IEntityEditor");
            }

            bool result = parent.OnUpdate();
            if (result) {
                OnSuccess(parent, EventArgs.Empty);
            } else {
                OnFailure(parent, EventArgs.Empty);
            }
        }

        #endregion Events

        #region Virtual Members

		/// <summary>
        /// Invokes all the listeners to the Success event
        /// </summary>
        /// <param name="src">Sender</param>
        /// <param name="args">Arguments</param>
        protected virtual void OnSuccess( object src, EventArgs args)
        {
            if (Success != null) {
                Success(src, args);
            }
        }

		/// <summary>
        /// Invokes all the listeners to the Failure event
        /// </summary>
        /// <param name="src">Sender</param>
        /// <param name="args">Arguments</param>
        protected virtual void OnFailure(object src, EventArgs args)
        {
            if (Failure != null) {
                Failure(src, args);
            }
        }

        #endregion Virtual Members
		
	};

}