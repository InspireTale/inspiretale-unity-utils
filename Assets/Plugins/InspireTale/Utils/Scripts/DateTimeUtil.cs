using System;

public static class DateTimeUtil
{
    private static DateTime StartUnixDateTime = new DateTime(1970, 1, 1);
    public static long ToUnixTimestamp(DateTime dateTime)
    {
        return (long)dateTime.Subtract(StartUnixDateTime).TotalSeconds;
    }

    public static long ToMsTimestamp(DateTime dateTime)
    {
        return (long)dateTime.Subtract(StartUnixDateTime).TotalMilliseconds;
    }
}
