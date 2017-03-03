using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Calculator.PCL
{
    public class Calculator
    {
        public int Add(int x, int y)

        {

            int z = x + y;

            return z;



        }



        public int Divide(int x, int y)

        {

            int z = x / y;

            return z;



        }

        public int Multiply(int x, int y)

        {

            int z = x * y;

            return z;



        }

        public int Subtract(int x, int y)

        {

            int z = x - y;

            return z;



        }

    }
}
