using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public class FirstRelationTSPSolver : ITSPSolver
    {
        //private List<Relation> relations = new List<Relation>();

        //public Relation[] Solve(City startNode)
        //{
        //    Relation r = startNode.Relations.First();
        //    do
        //    {
        //        if (!relations.Any(re => re.Current.Name == r.Next.Name))
        //        {
        //            relations.Add(r);
        //            r = GetFirstNotVisited(r.Next.Relations);
        //        }
        //        else
        //            r = null;
        //    }
        //    while (r != null);

        //    return relations.ToArray();
        //}

        //private Relation GetFirstNotVisited(List<Relation> list)
        //{
        //    return list.Where(r => !relations.Any(rel => rel.Current.Name == r.Next.Name)).FirstOrDefault();
        //}

        public IEnumerable<City> Solve(City startNode, IEnumerable<City> availableCities)
        {
            throw new NotImplementedException();
        }
    }
}
