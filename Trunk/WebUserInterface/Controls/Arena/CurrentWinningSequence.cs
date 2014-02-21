using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class CurrentWinningSequence : Control
    {
        private ArenaStorage arena;

        public ArenaStorage Arena
        {
            get { return arena; }
            set { arena = value; }
        }

        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            if(Arena.Historical.Count != 0)
            {

                writer.Write(Arena.Historical[Arena.Historical.Count-1].WinningSequence);
            }
            
        }

        #endregion Control Events        
        
    }
}
