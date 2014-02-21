using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Engine {


	public static class GraphicUtilities {

        public static IList<T> RotateElems<T>(IList<T> stats)
        {
            IList<T> rotated = new List<T>(stats.Count);

            for(int iter = stats.Count-1; iter >= 0; --iter)
            {
                rotated.Add(stats[iter]);
            }
            return rotated;
        }

        public static void GenerateGraphic(StringBuilder sb, IEnumerable<GlobalStats> stats, string title)
        {
            double[] yValues = GetYValues(stats);
            WriteGraphic(stats, sb, title, yValues);
        }

	    public static void GenerateGraphic(StringBuilder sb, IEnumerable<GlobalStats> stats, string title, int yMin, int yMax)
        {
            double[] yValues = GetYValues(yMin, yMax);
            WriteGraphic(stats, sb, title, yValues);
        }

        #region Private Methods

        private static void WriteScale(StringBuilder sb, double[] yValues)
        {
            sb.Append("&chds=");
            sb.Append(string.Format("{0},{1}", yValues[0], yValues[yValues.Length - 1]));
        }

        private static void WriteData(StringBuilder sb, IEnumerable<GlobalStats> stats)
        {
            sb.Append("&chd=t:");
            bool isFirst = true;
            foreach (GlobalStats value in stats)
            {
                if (isFirst)
                {
                    sb.Append(value.Number);
                    isFirst = false;
                }
                else
                {
                    sb.Append(string.Format(",{0}", value.Number));
                }
            }
        }

        private static void WriteYValues(StringBuilder sb, IEnumerable<double> yValues)
        {
            foreach (double val in yValues)
            {
                sb.Append(string.Format("|{0}", val));
            }
        }

        private static void WriteXValues(StringBuilder sb, IEnumerable<GlobalStats> stats)
        {
            foreach (GlobalStats data in stats)
            {
                sb.Append(string.Format("|{0}", data.Tick));
            }
        }

        private static double[] GetYValues(IEnumerable<GlobalStats> stats)
        {
            double[] toReturn = new double[9];

            double min = double.MaxValue, max = double.MinValue;

            foreach (GlobalStats value in stats)
            {
                if (min > value.Number)
                {
                    min = value.Number;
                }

                if (max < value.Number)
                {
                    max = value.Number;
                }
            }

            if (max - min < 10)
            {
                max += 10;
            }

            double gap = max - min;
            gap = Math.Ceiling(gap / 2 / 2 / 2);

            for (int iter = 0; iter < toReturn.Length; ++iter)
            {
                toReturn[iter] = (int)(min + iter * gap);
            }
            return toReturn;
        }

        private static double[] GetYValues(int min, int max)
        {
            double[] toReturn = new double[9];

            double gap = max - min;
            gap = Math.Ceiling(gap / 2 / 2 / 2);

            for (int iter = 0; iter < toReturn.Length; ++iter)
            {
                toReturn[iter] = (int)(min + iter * gap);
            }
            return toReturn;
        }

        private static void WriteGraphic(IEnumerable<GlobalStats> stats, StringBuilder sb, string title, double[] yValues)
        {
            sb.Append("<img alt='");
            sb.Append(title);
            sb.Append("' src='http://chart.apis.google.com/chart?chxt=x,y&cht=lc&chg=5,6.26,1,3&chco=ff0000&chm=x,8888ff,0,-1,8&chf=bg,s,161616|c,s,161616&chs=1000x300&chtt=");
            sb.Append(title);
            sb.Append("&chxl=0:");
            WriteXValues(sb, stats);
            sb.Append("|1:");
            WriteYValues(sb, yValues);
            WriteData(sb, stats);
            WriteScale(sb, yValues);
            sb.Append("' /><br/>");
        }

        #endregion Private Methods
	};
}
