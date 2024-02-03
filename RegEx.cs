string message = "[176749] [SSS] Azure Log Alert: SSSFTP01";
var pattern = @"\[([^]]*)\]";
string ticketId = Regex.Match(message, pattern).Groups[1].Value;
