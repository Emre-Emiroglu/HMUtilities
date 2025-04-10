using UnityEngine;

namespace CodeCatGames.HMUtilities.Runtime
{
    public static class TimeCalculator
    {
        #region Constants
        public const int DayAsSecond = 86400;
        public const int HourAsSecond = 3600;
        public const int HourAsDay = 24;
        public const int SecondAsDay = 60;
        #endregion
        
        #region Fields
        private static float _time;
        #endregion

        #region Executes
        public static void StartTimer() => _time = Time.realtimeSinceStartup;
        public static float StopTimer(string title = "")
        {
            float diff = Time.realtimeSinceStartup - _time;
            diff = diff < 0 ? 0 : diff;
            Debug.Log(title + "TIME::" + diff);
            return diff;
        }
        #endregion
    }
}