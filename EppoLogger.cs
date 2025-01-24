namespace eppo_spike;

using eppo_sdk.dto;
using eppo_sdk.dto.bandit;
using eppo_sdk.logger;
using Microsoft.Extensions.Logging;

internal class EppoLogger : IAssignmentLogger {
    private readonly ILogger<EppoLogger> _logger;

    public EppoLogger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<EppoLogger>();
    }

    public void LogAssignment(AssignmentLogData assignmentLogData) => _logger.LogDebug(
        "Feature flag {FeatureName} was evaluated and returned the {VariantName} variant",
        assignmentLogData.FeatureFlag, assignmentLogData.Variation);

    public void LogBanditAction(BanditLogEvent banditLogEvent)
    {
    }
}