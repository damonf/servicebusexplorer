using System;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public static class TimeSpanExtensions
    {
        public static string ToReadableString(this TimeSpan span)
        {
            var formatted = string.Format("{0}{1}{2}{3}",
                FormatPart(span.Duration().Days, "day"),
                FormatPart(span.Duration().Hours, "hour"),
                FormatPart(span.Duration().Minutes, "minute"),
                FormatPart(span.Duration().Seconds, "second"));

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }

        private static string FormatPart(int count, string title)
        {
            return count <= 0 ? string.Empty : $"{count:0} {title}{(count == 1 ? string.Empty : "s")}, ";
        }
    }
}
