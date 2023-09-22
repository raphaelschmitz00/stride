using Stride.Engine.Startup;

namespace UsageExamples;

public class Startup
{
    public static void Start()
    {
        var builder = StrideApplication.CreateBuilder();


        var game = builder.Build();


        game.Run();
    }
}
