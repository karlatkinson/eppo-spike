namespace eppo_spike;

using Microsoft.Extensions.Logging;

public class EppoFeatures
{
    private readonly IFeaturesRepository _featuresRepository;
    private readonly ILogger<EppoFeatures> _logger;

    public EppoFeatures(string sdkKey, ILoggerFactory loggerFactory)
    {
        _featuresRepository = new EppoFeaturesRepository(sdkKey, loggerFactory);
        _logger = loggerFactory.CreateLogger<EppoFeatures>();
    }

    public EppoFeatures(IFeaturesRepository featuresRepository, ILoggerFactory loggerFactory)
    {
        _featuresRepository = featuresRepository;
        _logger = loggerFactory.CreateLogger<EppoFeatures>();
    }

    public bool IsEnabled(string key)
    {
        try
        {
            _logger.LogDebug("Retrieving toggle for {FeatureKey}", key);
            return _featuresRepository.IsEnabled(key);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,
                "There was an exception getting feature status for {FeatureKey} defaulting to off", key);
            return false;
        }
    }
}