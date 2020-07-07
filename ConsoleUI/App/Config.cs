namespace ConsoleUI.App
{
    static class Config
    {
        public static bool Tested { get; private set; }

        public static void SetConfig(bool tested)
        {
            Tested = tested;
        }
    }
}
