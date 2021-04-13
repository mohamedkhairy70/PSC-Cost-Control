using System.Collections.Generic;


namespace PSC_Cost_Control.Helper
{
    public class GuidIntGenerator
    {
        private HashSet<int> Unique;
        private int Last;
        public GuidIntGenerator()
        {
            Unique = new HashSet<int>();
        }
        public void Block(int blocked)
        {
            if (!Unique.Contains(blocked))
                Unique.Add(blocked);
        }

        public int Guid()
        {
            while (Unique.Contains(++Last)) { }

            Unique.Add(Last);
            return Last;
        }
    }
}
