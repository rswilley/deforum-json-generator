using System.Text.Json.Serialization;

namespace DeforumFrameGenerator;

public class Settings
{
    [JsonPropertyName("videoLength")]
    public TimeSpan VideoLength { get; init; }
    [JsonPropertyName("fps")]
    public int Fps { get; init; }
    [JsonPropertyName("segmentLengthInSeconds")]
    public int SegmentLengthInSeconds { get; init; }
}