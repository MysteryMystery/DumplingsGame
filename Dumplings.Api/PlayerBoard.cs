using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api
{
    public class PlayerBoard
    {
        public PlayerBoard() { }

        public Dictionary<DumplingType, int> Dumplings { get; } = new();

        public List<DumplingType> CompletedSets { get; } = new();

        public void AddDumplings(params Dumpling[] dumplings)
        {
            foreach(var dumpling in dumplings)
            {
                if (Dumplings.ContainsKey(dumpling.DumplingType))
                {
                    // move to completed sets
                    if (Dumplings[dumpling.DumplingType] == 2 && !CompletedSets.Contains(dumpling.DumplingType))
                    {
                        CompletedSets.Add(dumpling.DumplingType);
                        Dumplings[dumpling.DumplingType] = 0;
                    } 
                    // increment
                    else
                    {
                        Dumplings[dumpling.DumplingType]++;
                    }
                }
                else
                {
                    Dumplings[dumpling.DumplingType] = 1;
                }
            }
        }
    }
}
