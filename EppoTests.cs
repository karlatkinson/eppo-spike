namespace eppo_spike;

using DotNetEnv;
using eppo_sdk;

public class EppoTests
{
    [Fact]
    public void CanCheckFeature()
    {
        Env.TraversePath().Load();
        var sdkKey = Env.GetString("EPPO_SDK_KEY");
        var featureFlag = Env.GetString("EPPO_FEATURE_FLAG");
        var eppoClient = EppoClient.Init(new EppoClientConfig(sdkKey, null));

        var result = eppoClient.GetBooleanAssignment(featureFlag, FakeSubject.Id, FakeSubject.Attributes, false);
        
        Assert.True(result);
    }
}

public static class FakeSubject
{
    public const string Id = "DummyUser";
    public static Dictionary<string, object> Attributes = new Dictionary<string, object>();
}