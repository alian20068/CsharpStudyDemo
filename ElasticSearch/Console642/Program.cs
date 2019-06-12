using Console642.Class;
using Nest;
using System;
using System.Linq;

namespace Console642
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);

            //elasticsearch-6.4.2.msi
            //NEST 6.0.0

            //创建索引
            ESProvider es = new ESProvider();
            es.PopulateIndex(new MeetupEvents
            {
                eventid = 2,
                eventname = "eventname2",
                orignalid = "orignalid2",
                description = "description1"
            });

            SearchRequest sr = new SearchRequest("meetup", "events");
            TermQuery tq = new TermQuery();
            tq.Field = "description";
            tq.Value = "description1";
            sr.Query = tq;
            var result = client.Search<MeetupEvents>(sr);
            var result2 = result.Documents.ToList<MeetupEvents>();

        }
    }
}
