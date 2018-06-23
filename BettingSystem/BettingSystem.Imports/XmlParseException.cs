using System;

namespace BettingSystem.Imports
{
    public class XmlParseException : Exception
    {
        public XmlParseException(
            string message = "Unable to parse xml.",
            Exception innerException = default)
            : base(message, innerException)
        {
        }
    }
}