namespace System
{
    internal static class DateTimeExtensions
    {
        public static string ElapsedTime(this DateTime thisObj)
        {
            TimeSpan duracao = DateTime.Now.Subtract(thisObj);
            if (duracao.TotalHours < 24)
            {
                var horas = duracao.Hours.ToString("F2") + ":" + duracao.Minutes.ToString("F2") + " horas";
                //return duracao.TotalHours.ToString("F1", CultureInfo.InvariantCulture) + " horas";
                return horas;
            }
            else
            {
                var dias = duracao.Days.ToString("F1") + " e " + duracao.Hours.ToString("F1") + " dias";
                //return duracao.TotalDays.ToString("F1", CultureInfo.InvariantCulture) + " dias";
                return dias;
            }
        }
    }
}