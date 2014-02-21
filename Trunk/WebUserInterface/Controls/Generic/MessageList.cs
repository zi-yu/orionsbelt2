using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Shows entity messages
    /// </summary>
	public class MessageList: Control {

        #region Properties

        private GenericMessages genericMessages;

        public GenericMessages MessagesWriter {
            get { return genericMessages; }
            set { genericMessages = value; }
        }

        private string css;

        public string Css
        {
            get { return css; }
            set { css = value; }
        }

        private bool includeImages;

        public bool IncludeImages
        {
            get { return includeImages; }
            set { includeImages = value; }
        }

        private bool includeEmptyMessage = true;

        public bool IncludeEmptyMessage
        {
            get { return includeEmptyMessage; }
            set { includeEmptyMessage = value; }
        }

        private bool includeElapsedTime;

        public bool IncludeElapsedTime
        {
            get { return includeElapsedTime; }
            set { includeElapsedTime = value; }
        }
	
        #endregion Properties

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            if (MessagesWriter != null) {
                MessagesWriter.Css = Css;
                MessagesWriter.IncludeImages = IncludeImages;
                MessagesWriter.IncludeElapsedTime = IncludeElapsedTime;
                MessagesWriter.IncludeEmptyMessage = IncludeEmptyMessage;
                MessagesWriter.Render(writer);
            }
        }

        #endregion Rendering

    };
}

