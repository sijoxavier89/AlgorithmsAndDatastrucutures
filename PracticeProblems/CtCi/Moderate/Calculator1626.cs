using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProblems.CtCi.Moderate
{
    /// <summary>
    /// Compute the reslut of the arithmetic sequence
    /// this works by reading the terms from left to right and 
    /// applying the term to a tesult. when we see multiplication or
    /// division we instead store the sequence to temperory variable 
    /// </summary>
    public class Calculator1626
    {
        public static double Compute(string equation)
        {
            var terms = Term.ParseTermSequence(equation);
            if(terms.Count == 0) return 0.0;

            double result = 0.0;
            Term processing = null;

            for(int i = 0; i < terms.Count; i++)
            {
                Term current = terms[i];
                Term next = (i + 1 < terms.Count) ? terms[i + 1] : null;

                // Apply the current term to the processing
                processing = CollapseTerm(processing, current);

                if(next == null || next.Op == Operator.ADD || next.Op == Operator.SUBTRACT)
                {
                    result = ApplyOp(result, processing.Op, processing.Value);
                    // clear processing
                    processing = null;
                }
            }
            return result;
        }

        /// <summary>
        /// Collapse two terms together with operator from secondary 
        /// and value from each
        /// </summary>
        /// <param name="primary"></param>
        /// <param name="secondary"></param>
        /// <returns> term </returns>
        private static Term CollapseTerm(Term primary, Term secondary)
        {
            if(primary == null) return secondary;
            if(secondary == null) return primary;

            double value = ApplyOp(primary.Value, secondary.Op, secondary.Value);
            primary.Value = value;

            return primary;
        }
        /// <summary>
        /// apply operation 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="op"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static double ApplyOp(double left, Operator op, double right)
        {
            if (op == Operator.ADD) return left + right;
            else if (op == Operator.SUBTRACT) return left - right;
            else if (op == Operator.MULTIPLY) return left * right;
            else if (op == Operator.DIVIDE) return left / right;
            else return right;
        }
        class Term
        {
            public Operator Op { get; }
            public double Value { get; set; }

           
            public Term(Operator op, double value)
            {
                Op = op;
                Value = value;
            }

            public static List<Term> ParseTermSequence(string sequence)
            {
                if (sequence == null) return new List<Term>();

                List<Term> terms = new List<Term>();
                int offset = 0;
                while (offset < sequence.Length)
                {
                    Operator op = Operator.BLANK;
                    if (offset > 0)
                    {
                        op = ParseOperator(sequence[offset]);
                        if (op == Operator.BLANK)
                        {
                            return null;
                        }
                        offset++;
                    }

                    // 
                    try
                    {
                        int value = ParseNextNumber(sequence, offset);
                        offset += value.ToString().Length;

                        Term term = new Term(op, value);
                        terms.Add(term);

                    }
                    catch (Exception ex)
                    {
                        return new List<Term>(); ;
                    }
                    
                }
                return terms;
            }

            private static int ParseNextNumber(String sequence, int offset)
            {
                StringBuilder sb = new StringBuilder();
                int num;
                while((sequence.Length > offset) && int.TryParse(sequence[offset].ToString(), out num))
                {
                   sb.Append(sequence[offset]);
                    offset++;
                }

                return int.Parse(sb.ToString());
            }
            public static Operator ParseOperator(char c)
            {
                Operator op = Operator.BLANK;
                if (c == '-')
                {
                    op = Operator.SUBTRACT;
                }
                else if(c == '+')
                {
                     op = Operator.ADD;
                }
                else if(c == '*')
                {
                    op = Operator.MULTIPLY;
                }
                else if (c == '/')
                {
                    op = Operator.DIVIDE;
                }

                return op;
                                
            }
        }
        public enum Operator
        {
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE,
            BLANK
        }
    }
}
