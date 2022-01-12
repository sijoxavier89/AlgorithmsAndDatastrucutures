using System.Collections.Generic;

namespace TestProject.CtCi.Moderate
{
    public class Calculator16
    {
        Stack<string> commandStack;
       public int Caluclate(string equation)
        {
            return 0;
        }

        private void CreateStack(string input)
        {
            commandStack = new Stack<string>();

            var elements = input.Split(new char[] { '+', '-', '/', '*' });

            foreach(var e in elements)
            {
                commandStack.Push(e);
            }

        }

        private int ExcecuteStack(Stack<string> cmdStack)
        {

            while(cmdStack.Count > 0)
            {
               
            }

            return 0;
        }
    }
}
