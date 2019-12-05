using System;
using System.Collections.Generic;

namespace aoc2 {

    class Register : ALU
    {
        
        public int index;
        public int rowLength = 4;
        public int[] register;

        public Register(string intCodesString)
        {
            String[] intCodes = intCodesString.Split(",");
            this.register = Array.ConvertAll(intCodes, s => int.Parse(s));
        }

        public bool done()
        {
            return this.index >= (this.register.Length - 2);
        }

        public void next()
        {
            this.index += this.rowLength;
        }

        public bool isExit()
        {
            return 99 == this.register[this.index];
        }

        /*
         * Executes current row of 4 integers
         *
         * @return int[location, value]
         */
        public void executeRow()
        {
            Func<int, int, int> opCode = this.OPCodes[this.register[this.index]];

            Dictionary<string, int> result = new Dictionary<string, int> {
                { "location", this.register[this.index + 3] },
                // (int) absolute jank holy shit
                { "value", opCode(this.register[this.register[this.index + 1]], this.register[this.register[this.index + 2]]) }
            };

            this.store(result);
        }

        public void store(Dictionary<string, int> result)
        {
            this.register[result["location"]] = result["value"];
        }

        public void print()
        {
            Console.WriteLine();
            foreach (int intCode in this.register) {
                Console.Write($"{intCode} ");
            }
            Console.WriteLine();
        }

    }

}
