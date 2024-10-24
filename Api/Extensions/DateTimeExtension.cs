namespace read_cloud.Extensions;

public static class DateTimeExtension
{
    private static readonly TimeZoneInfo timeZoneBrazil = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

    public static DateTime OnBrazil(this DateTime date) =>
        TimeZoneInfo.ConvertTime(date, timeZoneBrazil);
}
