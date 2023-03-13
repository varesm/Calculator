using System;
using System.Security.Cryptography;
using NUnit.Framework;
using Calculator.Application;
using Calculator.Application.Interfaces;

namespace Calculator.UnitTests;

public class CalculatorServiceTests
{
    private CalculatorService _calculatorService;
    
    [SetUp]
    public void Setup()
    {
        _calculatorService = new CalculatorService();
    }

    [Test]
    public void Add_Returns_Correct_Result()
    {
        //arrange
        double num1 = 4;
        double num2 = 5;
        double expected = 9;

        //act
        double actual = _calculatorService.Add(num1, num2);

        //assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Subtract_Return_Correct_Result()
    {
        //arrange
        double num1 = 7;
        double num2 = 3;
        double expected = 4;
        
        //act
        double actual = _calculatorService.Subtract(num1, num2);

        //assert
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void Multiply_Returns_Correct_Result()
    {
        //arrange
        double num1 = 3;
        double num2 = 3;
        double expected = 9;
        
        //act
        double actual = _calculatorService.Multiply(num1, num2);
        
        //assert
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void Divide_Returns_Correct_Result()
    {
        //arrange
        double num1 = 8;
        double num2 = 4;
        double expected = 2;
        
        //act
        double actual = _calculatorService.Divide(num1, num2);
        
        //assert
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void Divide_By_Zero_Throws_Exception()
    {
        //arrange
        double num1 = 4;
        double num2 = 0;
        
        //act & assert
        Assert.Throws<DivideByZeroException>(() => _calculatorService.Divide(num1, num2));
    }
}