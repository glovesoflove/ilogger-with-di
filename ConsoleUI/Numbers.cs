

namespace ConsoleUI

{
    class Numbers : IProcessor
    {
        public Numbers()
        {
        }

        public bool Process(string s)
        {

            Console.WriteLine("Number Processing");
            return true;
        }

    }
}
