using System;
using System.Collections.Generic;

namespace aoc2
{

    class Computer
    {
        public Register register;

        public Computer(string intCodes)
        {
            this.register = new Register(intCodes);
            this.process();
            register.print();
        }

        /*
         * Steps through register 4 integers at a time and executes with ALU
         *
         */
        public void process()
        {
            while (!this.register.done()) {
                // just listen for 99 out here :shrug:
                if (this.register.isExit()) {
                    register.print();
                    System.Environment.Exit(1);
                }
                this.register.executeRow();
                this.register.next();
            }
        }

    }

}
