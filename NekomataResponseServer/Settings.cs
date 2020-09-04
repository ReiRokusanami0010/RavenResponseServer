namespace NekomataResponseServer {
    public static class Settings {
        public static string Pass    { get; set; }
        public static string User    { get; set; }
        public static bool   IsLocal { get; set; }
        
        private static readonly string Localhost = "124.0.0.1"; 
        private static readonly string AWS       = "ec2-3-91-37-39.compute-1.amazonaws.com";
        public  static readonly string ServerUrl = IsLocal ? Localhost : AWS;
    }
}