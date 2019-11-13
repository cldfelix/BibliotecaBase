namespace System
{
    internal static class StringExtensions
    {
        public static string Cut(this string thisObj, int qtd)
        {
            if (thisObj.Length <= qtd)
                return thisObj;
            return thisObj.Substring(0, qtd) + "...";
        }
    }
}