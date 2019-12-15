using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IntcodeComputer.Opcodes;

namespace IntcodeComputer
{
    public class Computer
    {

        public string Commands { get; set; }
        private List<Opcode> opcodes = new List<Opcode>();

        public Computer()
        {
            opcodes.Add(new AdditionOpcode());
            opcodes.Add(new TerminateOpcode());
            opcodes.Add(new MultiplicationOpcode());
        }

        public int[] Run()
        {
            int[] input = this.Commands.Split(',').Select(x => int.Parse(x)).ToArray();
            int index = 0;
            int currentCode = input[index];
            int terminateOpcode = opcodes.Where(x => x.GetType() == typeof(TerminateOpcode)).Single().IntCode;

            do
            {

                foreach (Opcode opcode in opcodes)
                {
                    if (currentCode % 100 == opcode.IntCode)
                    {
                        input = opcode.Execute(input, index);
                        index += opcode.InputLength;
                        break;
                    }
                }

            } while ((currentCode = input[index]) != terminateOpcode);

            return input;

        }

    }
}
