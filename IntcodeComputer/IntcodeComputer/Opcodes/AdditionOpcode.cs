namespace IntcodeComputer.Opcodes
{
    internal class AdditionOpcode : Opcode, IOpcode
    {

        public AdditionOpcode() {
            this.IntCode = 01;
            this.InputLength = 4;
        }


        public override int[] Execute(int[] input, int index)
        {
            int code = input[index];
            PARAMETER_MODES inputOnePosMode = this.getModeByParameterPos(code, 1);
            PARAMETER_MODES inputTwoPosMode = this.getModeByParameterPos(code, 2);
            PARAMETER_MODES inputThreePosMode = this.getModeByParameterPos(code, 3);

            int newValue = this.getVariable(input, index + 1, inputOnePosMode) + this.getVariable(input, index + 2, inputTwoPosMode);

            input = this.setVariable(input, index + 3, newValue, inputThreePosMode);


            return input;
        }

    }
}