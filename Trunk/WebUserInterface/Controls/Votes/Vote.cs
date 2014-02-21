using System;
using System.Globalization;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Vote {
		#region Fields

		private string name;
		private DateTime lastVote;
		private static readonly char[] separator = new char[] { '#' };
        private static IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");

		#endregion Fields

		#region Properties

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public DateTime LastVote {
			get { return lastVote; }
			set { lastVote = value; }
		}

		#endregion Properties

		#region Public

		public override string ToString() {
			return string.Format("{0}#{1};", name, lastVote);
		}

		#endregion Public

		#region Constructor

		public Vote(string name, DateTime lastVote) {
			Name = name;
			LastVote = lastVote;
		}

		public Vote(string data) {
			string[] splittedData = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			name = splittedData[0];
            try {
                lastVote = DateTime.Parse(splittedData[1]);
            }catch(Exception) {
                lastVote = DateTime.Parse(splittedData[1], culture);
            }
		}

		#endregion Constructor

		
	}
}
