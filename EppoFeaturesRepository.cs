namespace eppo_spike;

using eppo_sdk;
using Microsoft.Extensions.Logging;

public interface IFeaturesRepository
{
    bool IsEnabled(string featureName);
}

public class EppoFeaturesRepository : IFeaturesRepository
{
    private readonly EppoClient _eppoClient;
    private const string SubjectKey = "AllUsers";
    private readonly Dictionary<string, object> _emptySubjectAttribute = new();

    public EppoFeaturesRepository(string eppoSdkKey, ILoggerFactory loggerFactory)
    {
        _eppoClient = EppoClient.Init(new EppoClientConfig(eppoSdkKey, new EppoLogger(loggerFactory)));
    }

    public bool IsEnabled(string featureName) =>
        _eppoClient.GetBooleanAssignment(featureName, SubjectKey, _emptySubjectAttribute, false);
}