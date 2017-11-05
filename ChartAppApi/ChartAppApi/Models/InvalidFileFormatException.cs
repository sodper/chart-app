namespace ChartAppApi.Models
{
    public class InvalidFileFormatException : System.FormatException
    {
        public string Line { get; set; }
        public int LineNumber { get; set; }

        public InvalidFileFormatException(string line, int lineNumber)
        {
            Line = line;
            LineNumber = lineNumber;
        }

        public override string ToString()
        {
            return $"Invalid file format on line {LineNumber}: \"{Line}\"";
        }
    }
}