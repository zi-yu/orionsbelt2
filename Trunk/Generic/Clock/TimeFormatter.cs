using System;
using OrionsBelt.Generic.Messages;
using System.IO;

namespace OrionsBelt.Generic {

    /// <summary>
    ///Converts time and ticks into strings
    /// </summary>
    public static class TimeFormatter {

        #region Static Utils

        public static string GetFormattedTicks(int ticks)
        {
            TimeSpan span = Clock.Instance.ConvertToTimeSpan(ticks);
            return GetFormattedTime(span);
        }

        public static string GetFormattedTicksTo(int ticks)
        {
            int totalTicks = ticks - Clock.Instance.Tick;
            TimeSpan span = Clock.Instance.ConvertToTimeSpan(totalTicks);
            return GetFormattedTime(span);
        }

        public static string GetFormattedTicksSince(int ticks)
        {
            TimeSpan span = Clock.Instance.ConvertToTimeSpan(Clock.Instance.Tick - ticks);
            return GetFormattedTime(span);
        }

        public static string GetFormattedTicksSince(DateTime time)
        {
            return GetFormattedTicks(TickClock.Instance.ConvertToTicks(new TimeSpan(DateTime.Now.Ticks) - new TimeSpan(time.Ticks)));
        }

        public static string GetFormattedTime(TimeSpan span)
        {
            using (TextWriter writer = new StringWriter()) {
                if (span.Days > 0) {
                    writer.Write(span.Days);
                    writer.Write(" ");
                    if (span.Days > 1) {
                        writer.Write(Translator.Translate("Days"));
                    } else {
                        writer.Write(Translator.Translate("Day"));
                    }
                    writer.Write(" ");
                }

                if (span.Hours > 0) {
                    writer.Write(span.Hours);
                    writer.Write(" ");
                    if (span.Hours > 1) {
                        writer.Write(Translator.Translate("Hours"));
                    } else {
                        writer.Write(Translator.Translate("Hour"));
                    }
                    writer.Write(" ");
                }

                if (span.Minutes > 0) {
                    writer.Write(span.Minutes);
                    writer.Write(" ");
                    if (span.Minutes > 1) {
                        writer.Write(Translator.Translate("Minutes"));
                    } else {
                        writer.Write(Translator.Translate("Minute"));
                    }
                    writer.Write(" ");
                }

                if (span.TotalSeconds < 60) {
                    writer.Write(Translator.Translate("Seconds"));
                }

                return writer.ToString();
            }
        }

        public static string GetFormattedTimeSmall(TimeSpan span) {
            using (TextWriter writer = new StringWriter()) {
                if (span.Days > 0) {
                    writer.Write("{0} ", span.Days);
                    writer.Write(" ");
                    if (span.Days > 1) {
                        writer.Write(Translator.Translate("Days"));
                    } else {
                        writer.Write(Translator.Translate("Day"));
                    }
                    return writer.ToString();
                }

                if (span.Hours > 0) {
                    writer.Write("{0} ", span.Hours);
                    if (span.Hours > 1) {
                        writer.Write(Translator.Translate("Hours"));
                    } else {
                        writer.Write(Translator.Translate("Hour"));
                    }
                    return writer.ToString();
                }

                if (span.Minutes > 0) {
                    writer.Write("{0} ", span.Minutes);
                    if (span.Minutes > 1) {
                        writer.Write(Translator.Translate("Minutes"));
                    } else {
                        writer.Write(Translator.Translate("Minute"));
                    }
                    return writer.ToString();
                }

                if (span.TotalSeconds < 60) {
                    writer.Write("{0} {1}", span.Seconds, Translator.Translate("Seconds"));
                }
                return writer.ToString();
            }
        }


        #endregion Static Utils

        #region Translator

        private static IMessageParameterTranslator translator;

        public static IMessageParameterTranslator Translator {
            get {return translator;  }
            set { translator = value; }
        }

        #endregion Translator

    };

}
