using Xunit;
using Calculator;

namespace CalcTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddition()
        {
            Assert.Equal(10, Program.Addition(5, 5));
            Assert.Equal(-10, Program.Addition(5, -15));
        }
        [Fact]
        public void TestAdditionArray()
        {
            double[] tArray = new double[]{ 1,2,3,4};
           Assert.Equal(10, Program.Addition(tArray));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        [InlineData(-2.5, 2.6, -2.5+2.6)]

        public void AdditionTheory(double value1, double value2, double expected)
        {
            var result = Program.Addition(value1, value2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSubtraction()
        {
            Assert.Equal(5, Program.Subtraction(10, 5));
        }
        [Fact]
        public void TestSubtractionArray()
        {
            double[] tArray = new double[] { 1, 2, 3, 4 };
            Assert.Equal(-8, Program.Subtraction(tArray));
        }

        [Fact]
        public void TestDivision()
        {
            var result = Program.Division(10, 2);       
            Assert.Equal(5, result.Result);
            Assert.False(result.Division0);
        }



        [Fact]
        public void Div0()
        {
            var result = Program.Division(5, 0);
            Assert.True(result.Division0);
        }


        [Theory]
        [InlineData(1, 2, false , (double)1/2)]
        [InlineData(7, 0, true, 0)]
        [InlineData(10, 2, false, 5)]
        public void TheoryDivision(double value1, double value2, bool div0, double expected)
        {
            var result = Program.Division(value1, value2);
            Assert.Equal(div0, result.Division0);
            Assert.Equal(expected, result.Result);
        }

        [Fact]
        public void TestMultiplication()
        {         
            Assert.Equal(25, Program.Multiplication(5,5));
        }

        [Fact]
        public void ArrayMakerTest()
        {
            double[] testArray = new double[] { 12.2, 3, 1, 0.1, 5.555 };
            Assert.Equal(testArray, Program.ArrayMaker("ä12,2ädw3d1pp,1hej5,5,5,5"));
        }
    }
}