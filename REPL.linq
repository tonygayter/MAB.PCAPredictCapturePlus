<Query Kind="Program">
  <Reference Relative="MAB.PCAPredictCapturePlus\bin\Debug\MAB.PCAPredictCapturePlus.dll">C:\Src\MAB.PCAPredictCapturePlus\MAB.PCAPredictCapturePlus\bin\Debug\MAB.PCAPredictCapturePlus.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>MAB.PCAPredictCapturePlus</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Net</Namespace>
  <AppConfig>
    <Path Relative="REPL.config">C:\Src\MAB.PCAPredictCapturePlus\REPL.config</Path>
  </AppConfig>
</Query>

void Main()
{
    var key = ConfigurationManager.AppSettings["PCAPredictCapturePlusKey"];

    var client = new CapturePlusClient("2.10", key, "GBR", "EN");
    
    var findResults = client.Find("WR5 3DA");
    
	if (findResults.Error != null)
	{
		findResults.Error.Dump();
	}
	else
	{
		findResults.Items.Dump();
	}
	
    var retrieveResults = client.Retrieve("GBR|52509479");

	if (retrieveResults.Error != null)
	{
		retrieveResults.Error.Dump();
    }
	else
	{
	    retrieveResults.Items.Select(a => new {
	        Company = a.Company,
	        BuildingName = a.BuildingName,
	        Street = a.Street,
	        Line1 = a.Line1,
	        Line2 = a.Line2,
	        Line3 = a.Line3,
	        Line4 = a.Line4,
	        Line5 = a.Line5,
	        City = a.City,
	        County = a.Province,
	        Postcode = a.PostalCode
	    }).First().Dump();
	}
}