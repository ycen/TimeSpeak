using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TimeSpeak
{
    
public class Rootobject
{
public string status { get; set; }
public string copyright { get; set; }
public string section { get; set; }
public DateTime last_updated { get; set; }
public int num_results { get; set; }
public List<Result> results { get; set; }
}

public class Result
{
    public string section { get; set; }
    public string subsection { get; set; }
    public string title { get; set; }
    public string abstra { get; set; }
    public string url { get; set; }
    public string byline { get; set; }
    public string item_type { get; set; }
    public DateTime updated_date { get; set; }
    public DateTime created_date { get; set; }
    public DateTime published_date { get; set; }
    public string material_type_facet { get; set; }
    public string kicker { get; set; }
    public string[] des_facet { get; set; }
    public object org_facet { get; set; }
    public object per_facet { get; set; }
    public object geo_facet { get; set; }
    public object multimedia { get; set; }
}

}
