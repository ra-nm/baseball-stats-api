#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;
using System.Text;
using Newtonsoft.Json;

public static HttpResponseMessage Run(HttpRequestMessage req, IQueryable<Salaries> inTable, TraceWriter log)
{
    string teamId = req.GetQueryNameValuePairs()
                 .FirstOrDefault(q => string.Compare(q.Key, "teamId", true) == 0)
                 .Value;

    string yearId = req.GetQueryNameValuePairs()
                 .FirstOrDefault(q => string.Compare(q.Key, "yearId", true) == 0)
                 .Value;         

    int yearIdInt = Convert.ToInt32(yearId);

    if (teamId == "MIL" && yearIdInt <= 1997)
    {
        teamId = "ML4";
    }

    var result = inTable.Where(s => s.YearId == yearIdInt && s.TeamId == teamId).ToList();
   
    var json = JsonConvert.SerializeObject(result, Formatting.Indented);
    return new HttpResponseMessage(HttpStatusCode.OK)
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };

}

public class Salary : TableEntity
{
    public string LeagueId { get; set; }
    public int YearId { get; set; }
    public string PlayerId { get; set; }
    public string TeamId { get; set; }
    public int Salary { get; set; }
}
