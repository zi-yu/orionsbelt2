using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.XPath;
using System.Threading;
using System.Resources;
using System.Globalization;
using System.Reflection;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents {

   /// <summary>
    /// This interface resolves language tokens
    /// </summary>
	public interface ILanguageHandler {

        string Get(string token);

    };
}
