using System;
using System.Collections.Generic;

namespace aoc5
{

    class Computer
    {
        public Register register;
        public string intCodes;

        public Computer(string[] args)
        {
            this.intCodes = args[0];
            switch(args.Length) {
                case 3:
                    this.reverse(int.Parse(args[2]));
                    break;
                case 1:
                    this.register = new Register(this.intCodes);
                    this.process();
                    register.print();
                    break;
                default:
                    Console.WriteLine("Fix your shit bro");
                    break;
            }
        }

        public void reverse(int reverseResult)
        {
            for (int x = 0; x < 100; x++) {
                for (int y = 0; y < 100; y++) {
                    this.register = new Register(this.intCodes);
                    this.register.store(new Dictionary<string, int> {
                        { "location", 1 },
                        { "value", x },
                    });
                    this.register.store(new Dictionary<string, int> {
                        { "location", 2 },
                        { "value", y },
                    });
                    this.process();
                    if (this.register.register[0] == reverseResult) {
                        register.print();
                    }
                }
            }
        }

        /*
         * Steps through register 4 integers at a time and executes with ALU
         *
         */
        public void process()
        {
            while (!this.register.done()) {
                this.register.executeRow();
                this.register.next();
            }
        }

    }

}
