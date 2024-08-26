namespace FoodieAPI.Tests;

public class UnitTest1
{
    [Fact(DisplayName = "It should return a sum of two numbers")]
    public void ShouldSumOfTwoNumbers()
    {
        const int resultExpected = 5;
        const int firstNumber = 3;
        const int secondNumber = 2;
        
        var sumOfNumbers = firstNumber + secondNumber;
        
        Assert.Equal(resultExpected, sumOfNumbers);
    }
}