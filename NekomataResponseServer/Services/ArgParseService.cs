using System;

namespace NekomataResponseServer.Services {
    public static class ArgParseService {
        public static void Decomposition(string[] targetArgs) {
            try {
                for (int i = 0; i < targetArgs.Length; i++) {
                    switch (targetArgs[i]) {
                        case "--user":
                            Settings.User = targetArgs[++i];
                            break;
                        
                        case "--pass":
                            Settings.Pass = targetArgs[++i];
                            break;
                    }
                }
            } catch (ArgumentException e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}