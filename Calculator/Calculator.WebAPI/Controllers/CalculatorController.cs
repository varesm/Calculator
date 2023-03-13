using Microsoft.AspNetCore.Mvc;
using Calculator.Application;
using Calculator.Application.Interfaces;
using Calculator.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace Calculator.WebAPI.Controllers;

/// <summary>
/// Calculator API
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;

    private readonly ILogger<CalculatorController> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="calculatorService"></param>
    public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculatorService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    /// <summary>
    /// Add two numbers
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns>the sum of two numbers.</returns>
    /// <response code="200">The result of the addition</response>
    [HttpGet(Name = "add")]
    public ActionResult<CalculatorResult> Add(double num1, double num2)
    {
        var result = new CalculatorResult { Result = _calculatorService.Add(num1, num2) };
        return Ok(result);
    }
    
    /// <summary>
    /// Subtract two numbers
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns>the difference between two numbers.</returns>
    /// <response code="200">The result of the subtraction</response>
    [HttpGet(Name = "subtract")]
    public ActionResult<CalculatorResult> Subtract(double num1, double num2)
    {
        var result = new CalculatorResult { Result = _calculatorService.Subtract(num1, num2) };
        return Ok(result);
    }
    
    /// <summary>
    /// Multiply two numbers
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns>the product of two numbers.</returns>
    /// <response code="200">The result of the multiplication</response>
    [HttpGet(Name = "multiply")]
    public ActionResult<CalculatorResult> Multiply(double num1, double num2)
    {
        var result = new CalculatorResult { Result = _calculatorService.Multiply(num1, num2) };
        return Ok(result);
    }
    /// <summary>
    /// Divide two numbers
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2">Shouldn't be zero</param>
    /// <returns>the quotient of two numbers.</returns>
    /// <response code="200">The result of the division</response>
    /// <response code="400">The second number cannot be zero</response>
    [HttpGet(Name = "divide")]
    public ActionResult<CalculatorResult> Divide(double num1, double num2)
    {
        try
        {
            var result = new CalculatorResult { Result = _calculatorService.Divide(num1, num2) };
            return Ok(result);
        }
        catch (DivideByZeroException)
        {
            return BadRequest("Cannot divide by zero!");
        }
    }
    
}