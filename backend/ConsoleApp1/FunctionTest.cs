using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class FunctionTest
    {
        public static void Function_ReturnsPickachuIfZero_ReturnsString()
        {
            try
            {
                //Arrange
                int num = 0;
                Function function = new();
                //Act
                string result = function.ReturnsPickachuIfZero(num);

                //Assert
                if (result == "Pickachu")
                {
                    Console.WriteLine("Passed: Function_ReturnsPickachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("Failed: Function_ReturnsPickachuIfZero_ReturnsString");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
