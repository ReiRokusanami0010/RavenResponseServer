using Log5RLibs.Services;

namespace NekomataResponseServer.Schemes {
    public static class LoggerScheme {
        private const int MAX_INDEX = -15;
        private static readonly string DB_INFO = $"{"Server Access"    , MAX_INDEX}";
        
        public static readonly AlCConfigScheme DB_INFO_C = new AlCConfigScheme(0, DB_INFO, $"{"DataBase", MAX_INDEX}");
    }
}