namespace ChartAppApi.Models
{
    public class InvalidFileFormatException : System.FormatException
    {
        public string Line { get; set; }
        public int LineNumber { get; set; }

        public InvalidFileFormatException(string line, int lineNumber) : base($"Invalid file format on line {lineNumber}: \"{line}\"")
        {
            Line = line;
            LineNumber = lineNumber;
        }
    }
}