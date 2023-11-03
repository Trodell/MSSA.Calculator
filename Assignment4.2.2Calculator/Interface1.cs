using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4._2._2Calculator
{
    internal interface ICalculator
    {
        decimal Add(decimal x, decimal y);
        decimal Subtract(decimal x, decimal y);
        decimal Multiply(decimal x, decimal y);
        decimal Divide(decimal x, decimal y);

    }
    class Calculator : ICalculator
    {
        public decimal Add(decimal x, decimal y)
        {
            try
            {
                return x + y;
            }
            catch(OverflowException) //Returns 0 if the result is outside the bounds of the decimal
            {
                return 0;
            }
           
        }
        public decimal Subtract(decimal x, decimal y)
        {
            try
            {
                return x - y;
            }
            catch (OverflowException)
            {
                return 0;
            }
               
        }
        public decimal Multiply(decimal x, decimal y)
        {
            try
            {
                return x * y;

            }
            catch (OverflowException)
            {
                return 0;
            }
            
        }
        public decimal Divide(decimal x, decimal y)
        {
            try
            {
                if (x != 0 || y != 0)
                {
                    return x / y;
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
        }
       
        

    

    }
}
