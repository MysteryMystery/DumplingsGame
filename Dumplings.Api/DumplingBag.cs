using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api
{
    public class DumplingBag
    {
        private Dictionary<DumplingType, int> _dumplings;

        public DumplingBag()
        {
            InitialiseBag();
        }

        private void InitialiseBag()
        {
            _dumplings = new();
            foreach(string t in Enum.GetNames(typeof(DumplingType))) {
                _dumplings[Enum.Parse<DumplingType>(t)] = 5;
            }
        }

        public Dictionary<DumplingType, int> Draw(int count = 1)
        {
            Random random = new();
            Dictionary<DumplingType, int> drawn = new();
            for(int i = 0; i < count; i++)
            {
                KeyValuePair<DumplingType, int> k;
                do
                {
                    k = _dumplings.ElementAt(random.Next(0, _dumplings.Count));
                } while (k.Value == 0);

                drawn[k.Key]++;
                _dumplings[k.Key]--;
            }

            return drawn;
        }

        public Dictionary<DumplingType, int> Dumplings => _dumplings;
    }
}
