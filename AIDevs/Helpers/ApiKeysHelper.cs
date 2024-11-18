namespace AIDevs.Helpers
{
    public static class ApiKeysHelper
    {
        public static Tuple<string, string> Get()
        {
            var keys = File.ReadLines("keys.txt").ToList();

            return Tuple.Create(keys[0], keys[1]);
        }
    }
} 