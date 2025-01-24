namespace eppo_spike;

using eppo_sdk;
using Microsoft.Extensions.Logging;

public class Features
{
    private readonly EppoClient _eppoClient;

    public Features(string sdkKey, ILoggerFactory loggerFactory)
    {
        _eppoClient = EppoClient.Init(new EppoClientConfig(sdkKey, new EppoLogger(loggerFactory)));
    }

    public bool IsEnabled(string featureName) =>
        _eppoClient.GetBooleanAssignment(featureName, FakeSubject.Id, FakeSubject.Attributes, false);
}