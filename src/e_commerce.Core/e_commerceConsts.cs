using e_commerce.Debugging;

namespace e_commerce
{
    public class e_commerceConsts
    {
        public const string LocalizationSourceName = "e_commerce";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7695034f3bc44995b93c2577281d51c2";
    }
}
