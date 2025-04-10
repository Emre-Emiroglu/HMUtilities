using System;

namespace CodeCatGames.HMUtilities.Runtime
{
    public static class TextFormatter
    {
        #region Constants
        private const string Days = "{0:00}:";
        private const string Hours = "{1:00}:";
        private const string Minutes = "{2:00}:";
        private const string Seconds = "{3:00}:";
        private const string Milliseconds = "{4:00}";
        #endregion

        #region Executes
        public static string FormatNumber(int num) =>
            num switch
            {
                >= 100000000 => (num / 1000000D).ToString("0.#M"),
                >= 1000000 => (num / 1000000D).ToString("0.##M"),
                >= 100000 => (num / 1000D).ToString("0.#k"),
                >= 10000 => (num / 1000D).ToString("0.##k"),
                _ => num.ToString("#,0")
            };
        public static string FormatTime(double totalSecond,
            TimeFormattingTypes timeFormattingType = TimeFormattingTypes.DaysHoursMinutesSeconds,
            bool withMilliSeconds = false)
        {
            TimeSpan time = TimeSpan.FromSeconds(totalSecond);
            int days = time.Days;
            int hours = time.Hours;
            int minutes = time.Minutes;
            int seconds = time.Seconds;
            int milliSeconds = (int)(totalSecond * 100);
            milliSeconds %= 100;

            bool withDays = timeFormattingType == TimeFormattingTypes.DaysHoursMinutesSeconds;
            bool withHours = timeFormattingType is TimeFormattingTypes.DaysHoursMinutesSeconds
                or TimeFormattingTypes.HoursMinutesSeconds;
            bool withMinutes = timeFormattingType is TimeFormattingTypes.DaysHoursMinutesSeconds
                or TimeFormattingTypes.HoursMinutesSeconds or TimeFormattingTypes.MinutesSeconds;

            string d = withDays ? Days : null;
            string h = withHours ? Hours : null;
            string m = withMinutes ? Minutes : null;
            string ms = withMilliSeconds ? Milliseconds : null;

            string result = string.Format(d + h + m + Seconds + ms, days, hours, minutes, seconds, milliSeconds);
            result = result.TrimEnd(':');
            return result;
        }
        #endregion
    }
}