namespace IntcodeComputer.Opcodes
{
    internal class TerminateOpcode : Opcode, IOpcode
    {
        public TerminateOpcode()
        {
            this.IntCode = 99;
            this.InputLength = 0;
        }

        public string[] Execute(int[] input, int index)
        {
            throw new System.NotImplementedException();
        }
    }
}