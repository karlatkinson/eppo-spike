namespace eppo_spike;

using DotNetEnv;
using Xunit.Abstractions;

public class EppoTests
{
    private readonly EppoFeatures _eppoClient;
    private readonly string _featureFlag;

    public EppoTests(ITestOutputHelper logger)
    {
        Env.TraversePath().Load();
        _featureFlag = Env.GetString("EPPO_FEATURE_FLAG");
        var sdkKey = Env.GetString("EPPO_SDK_KEY");
        _eppoClient = new EppoFeatures(sdkKey, logger.ToLoggerFactory());
    }
    
    [Fact]
    public void CanCheckFeature()
    {
        var result = _eppoClient.IsEnabled(_featureFlag);
        
        Assert.True(result);
    }
    
    [Fact]
    public void CanCheckFeatureThatDoesNotExist()
    {
        var result = _eppoClient.IsEnabled("random-feature-toggle");
        
        Assert.False(result);
    }
}

public class EppoSecondTests
{
    private readonly EppoFeatures _eppoClient;
    private readonly string _featureFlag;

    public EppoSecondTests(ITestOutputHelper logger)
    {
        Env.TraversePath().Load();
        _featureFlag = Env.GetString("EPPO_FEATURE_FLAG");
        var sdkKey = Env.GetString("EPPO_SDK_KEY");
        _eppoClient = new EppoFeatures(sdkKey, logger.ToLoggerFactory());
    }
    
    [Fact]
    public void CanCheckFeature()
    {
        var result = _eppoClient.IsEnabled(_featureFlag);
        
        Assert.True(result);
    }
    
    [Fact]
    public void CanCheckFeatureThatDoesNotExist()
    {
        var result = _eppoClient.IsEnabled("random-feature-toggle");
        
        Assert.False(result);
    }
}