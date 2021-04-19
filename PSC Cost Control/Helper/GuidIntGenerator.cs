using System;
using System.Collections.Generic;


namespace PSC_Cost_Control.Helper
{
    public class GuidIntGenerator
    {
        private HashSet<int> _unique;
        private Random _random;
        public GuidIntGenerator()
        {
            _unique = new HashSet<int>();
            _random = new Random();
        }
        public void Block(int blocked)
        {
            if (!_unique.Contains(blocked))
                _unique.Add(blocked);
        }
        
        public int Guid()
        {
            int rand ;
            while (_unique.Contains(rand=_random.Next(100,10000000))) { }

            _unique.Add(rand);
            return rand;
        }

        public bool IsBlocked(int accused)
        {
            return _unique.Contains(accused);
        }
    }
}
