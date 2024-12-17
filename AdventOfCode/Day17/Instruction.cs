namespace AdventOfCode.Day17
{
    public class Instruction
    {
        public int OpCode { get; set; }
        public int Operand { get; set; }
        public Instruction(int opCode, int operand)
        {
            OpCode = opCode;
            Operand = operand;
        }
        public string Operation
        {
            get {
                switch (OpCode)
                {
                    case 0:
                        return "adv";
                    case 1:
                        return "bxl";
                    case 2:
                        return "bst";
                    case 3:
                        return "jnz";
                    case 4:
                        return "bxc";
                    case 5:
                        return "out";
                    case 6:
                        return "bdv";
                    default:
                        return "cdv";
                }
            }
        }
        public int GetCombo(int registerA, int registerB, int registerC)
        {
                switch (Operand)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        return Operand;
                    case 4:
                        return registerA;
                    case 5:
                        return registerB;
                    case 6:
                        return registerC;
                    default:
                        return -1;
                }
            }
        }
    }
}
