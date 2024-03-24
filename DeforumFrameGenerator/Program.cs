// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using DeforumFrameGenerator;

Console.WriteLine("Loading settings...");

await using var stream = new FileStream("settings.json", FileMode.Open);
var settings = await JsonSerializer.DeserializeAsync<Settings>(stream);

var totalSeconds = settings!.VideoLength.TotalSeconds;
var totalFrames = totalSeconds * settings.Fps;

var segmentCount = totalSeconds / settings.SegmentLengthInSeconds;
var frameIteration = (int)(totalFrames / segmentCount);

var output = new Dictionary<string, string>();
var frameIndex = 0;

for (int i = 0; i < segmentCount; i++)
{
    output.Add(frameIndex.ToString(), "");
    frameIndex += frameIteration;
}

Console.WriteLine($"Total Frames: {totalFrames + settings.Fps}");
Console.WriteLine("Deforum JSON: " + JsonSerializer.Serialize(output, new JsonSerializerOptions
{
    WriteIndented = true
}));
Console.ReadKey();
