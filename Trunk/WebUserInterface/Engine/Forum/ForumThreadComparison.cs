using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public class ForumThreadComparison : IComparer<ForumThread>{

        #region Fields

        public static ForumThreadComparison forumThreadComparison = new ForumThreadComparison();

        #endregion Fields

        #region Properties

        public static ForumThreadComparison Instance {
            get { return forumThreadComparison; }    
        }

        #endregion Properties

        #region IComparer<ForumThread> Members

        public int Compare(ForumThread x, ForumThread y) {
            return x.UpdatedDate.CompareTo(y.UpdatedDate);
        }

        #endregion
    }
}
