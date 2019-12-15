namespace IntcodeComputer.Opcodes
{
    internal interface IOpcode
    {

        int[] Execute(int[] input, int index);

    }
}