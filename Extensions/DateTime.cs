
using System;
using System.Globalization;

namespace fin_app_backend.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
      int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
      return dt.AddDays(-1 * diff).Date;
    }

    public static DateTime AddWeeks(this DateTime dt, int weeks)
    {
      GregorianCalendar gc = new GregorianCalendar();
      return gc.AddWeeks(dt, weeks);
    }

    public static int DifferenceInDays(this DateTime dt, DateTime other)
    {
      TimeSpan span = dt.Subtract(other);
      return (int)span.TotalDays;
    }

    public static int GetIso8601WeekOfYear(this DateTime time)
    {
      var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
      if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
      {
        time = time.AddDays(3);
      }
      return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
  }
}
