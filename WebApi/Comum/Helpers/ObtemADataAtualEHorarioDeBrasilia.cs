using System;

namespace Comum.Helpers;

public static class ObtemADataAtualEHorarioDeBrasilia
{
    public static DateTime Obter()
    {
        DateTime dateTime = DateTime.UtcNow;
        TimeZoneInfo horaBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(dateTime, horaBrasilia);
    }
}
