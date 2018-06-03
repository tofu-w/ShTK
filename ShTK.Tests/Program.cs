using OpenTK;

namespace ShTK.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (App app = new TestApp())
                app.Run();
        }
    }
}
