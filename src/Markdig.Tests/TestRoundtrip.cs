using Markdig.Renderers.Roundtrip;
using Markdig.Syntax;
using NUnit.Framework;
using System.IO;

namespace Markdig.Tests
{
    internal static class TestRoundtrip
    {
        internal static void TestSpec(string markdownText, string expected, string extensions, string context = null)
        {
            RoundTrip(markdownText, context);
        }

        internal static void RoundTrip(string markdown, string context = null)
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            pipelineBuilder.EnableTrackTrivia();
            MarkdownPipeline pipeline = pipelineBuilder.Build();
            MarkdownDocument markdownDocument = Markdown.Parse(markdown, pipeline);
            var sw = new StringWriter();
            var nr = new RoundtripRenderer(sw);

            nr.Write(markdownDocument);

            var result = sw.ToString();
            TestParser.PrintAssertExpected("", result, markdown, context);
        }
    }
}
