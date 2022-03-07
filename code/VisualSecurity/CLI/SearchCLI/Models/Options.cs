using CommandLine;

namespace SearchCLI.Models
{
    internal class Options
    {
        [Option("name", Required = true, HelpText = "Use the name of a known Security Camera")]
        public string Name { get; set; }
    }
}
