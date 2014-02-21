using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public class ForumPostComparison : IComparer<ForumPost> {

        #region Fields

        public static ForumPostComparison forumPostComparison = new ForumPostComparison();

        #endregion Fields

        #region Properties

        public static ForumPostComparison Instance {
            get { return forumPostComparison; }    
        }

        #endregion Properties

        #region IComparer<ForumThread> Members

        public int Compare(ForumPost x, ForumPost y) {
            return x.CreatedDate.CompareTo(y.CreatedDate);
        }

        #endregion
    }
}
