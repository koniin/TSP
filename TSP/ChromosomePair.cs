using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class ChromosomePair
    {
        public Chromosome Father { get; private set; }
        public Chromosome Mother { get; private set; }

        public ChromosomePair(Chromosome father, Chromosome mother)
        {
            Father = father;
            Mother = mother;
        }

        public Chromosome CreateCrossoverChild() 
        {
            return Father;
        }
        
        public Chromosome CreateChild()
        {
            return Father;
        }
    }
}
