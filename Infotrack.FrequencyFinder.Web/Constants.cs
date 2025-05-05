namespace Infotrack.FrequencyFinder.Web
{
    /// <summary>
    /// Constants used throughout the application.
    /// </summary>
    public class Constants
    {
        public const string Google = "Google";
        public const string Bing = "Bing";
        public const string Yahoo = "Yahoo";

        public const string InputPattern = "^[a-z A-Z0-9*]+$";
        public const string UrlPattern = @"^(http|https):\/\/[^\s$.?#].[^\s]*$";
        public const string HeaderKeyPattern = @"^[!#$%&'*+\-.^_`|~0-9a-zA-Z]+$";
        public const string HeaderValuePattern = @"^[^'\"";:<>|]*$";
        public const string HeaderValueSqlInjectionPattern = @"\b(drop|select|insert|delete|update|alter|create|exec|union|--|;)\b";
        public const string HeaderValueXssPattern1 = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>";
        public const string HeaderValueXssPattern2 = @"<[^>]+>";
        public const string HeaderValueXssPattern3 = @"javascript:";
        public const string HeaderValueXssPattern4 = @"on\w+=";
        public const string HeaderValueXssPattern5 = @"\b(alert|confirm|prompt)\b";
        public const string HeaderValueXssPattern6 = @"\b(eval|exec|execute)\b";
        public const string HeaderValueXssPattern7 = @"\b(document|window|location)\b";
        public const string HeaderValueXssPattern8 = @"\b(iframe|frame|frameset|object|embed)\b";
        public const string HeaderValueXssPattern9 = @"\b(src|href|action|method)\b";
        public const string HeaderValueXssPattern10 = @"\b(on\w+|style|class|id)\b";
        public const string HeaderValueXssPattern11 = @"\b(visibility|display|position|z-index)\b";
        public const string HeaderValueCommandInjectionPattern = @"(?i)(cmd|exec|exec\(\)|system|shell|os.system|os.popen|popen|popen2|popen3|popen4)\s*\(";
        public const string HeaderValueLdapInjectionPattern = @"(?i)(ldap|bind|search|modify|add|delete|rename|compare|abandon|extended)\s*\(";
        public const string HeaderValueXpathInjectionPattern = @"(?i)(xpath|xml|document|node|element|attribute|text|comment|processing-instruction)\s*\(";

        // Add more search engines as needed
    }
}
