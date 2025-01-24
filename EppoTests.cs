namespace eppo_spike;

using DotNetEnv;
using Xunit.Abstractions;

public class EppoTests
{
    private readonly Features _eppoClient;

    public EppoTests(ITestOutputHelper logger)
    {
        Env.TraversePath().Load();
        var sdkKey = Env.GetString("EPPO_SDK_KEY");
        _eppoClient = new Features(sdkKey, logger.ToLoggerFactory());
    }
    
    [Fact]
    public void CanCheckFeature()
    {
        var featureFlag = Env.GetString("EPPO_FEATURE_FLAG");

        var result = _eppoClient.IsEnabled(featureFlag);
        
        Assert.True(result);
    }
}