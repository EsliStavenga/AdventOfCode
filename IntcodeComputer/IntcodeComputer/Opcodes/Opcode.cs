using System;

namespace IntcodeComputer.Opcodes
{
    internal abstract class Opcode : IOpcode
    {

        public int IntCode { get; protected set; } = 99;
        public int InputLength { get; protected set; } = 0;

        protected enum PARAMETER_MODES { POSITION = 0, IMIDIATE = 1 }

        protected int getVariableFromPositionMode(int[] input, int index)
        {
            return getVariableFromImidiateMode(input, input[index]);
        }

        protected int getVariableFromImidiateMode(int[] input, int index)
        {
            return input[index];
        }

        protected int[] setVariableFromPositionMode(int[] input, int index, int newValue)
        {
            return setVariableFromImidiateMode(input, input[index], newValue);
        }

        protected int[] setVariableFromImidiateMode(int[] input, int index, int newValue)
        {
            input[index] = newValue;

            return input;
        }

        protected int getVariable(int[] input, int index, PARAMETER_MODES mode = PARAMETER_MODES.POSITION)
        {
            if(mode == PARAMETER_MODES.POSITION)
            {
                return this.getVariableFromPositionMode(input, index);
            } else
            {
                return this.getVariableFromImidiateMode(input, index);
            }
        }

        protected int[] setVariable(int[] input, int index, int newValue, PARAMETER_MODES mode = PARAMETER_MODES.POSITION)
        {
            if(mode == PARAMETER_MODES.POSITION)
            {
                return this.setVariableFromPositionMode(input, index, newValue);
            } else
            {
                return this.setVariableFromImidiateMode(input, index, newValue);
            }
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="parameter"> The xth parameterm, 1, 2, 3 etc</param>
        /// <returns></returns>
        protected PARAMETER_MODES getModeByParameterPos(int opcode, int parameter)
        {
            string code = opcode.ToString("D5");
//            int opcodeLength = code.Length;
            PARAMETER_MODES returnValue = PARAMETER_MODES.POSITION; //default mode is position mode
            
            //calculate the index needed
            //e.g. parameter required = 3, 3 - 3 = 0
            //parameter required = 1, 3 - 1 = 2
            int index = 3 - parameter; 
            if(code[index] == '1') //set mode to imidiate
            {
                returnValue = PARAMETER_MODES.IMIDIATE;
            }


            return returnValue;
        }

        public virtual int[] Execute(int[] input, int index)
        {
            throw new NotImplementedException();
        }
    }
}

//1002
//10002
//00102

