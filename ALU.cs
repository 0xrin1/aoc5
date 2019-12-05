using System;
using System.Collections.Generic;

namespace aoc2
{

    class ALU
    {

        public Dictionary<int, Func<int, int, int>> OPCodes;
    
        public ALU()
        {
            this.OPCodes = new Dictionary<int, Func<int, int, int>> {
                { 1, this.add },
                { 2, this.multiply },
            };
        }

        public int add(int first, int second)
        {
            return first + second;
        }

        public int multiply(int first, int second)
        {
            return first * second;
        }

    }

}
