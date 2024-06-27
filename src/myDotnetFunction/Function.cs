using Amazon.Lambda;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace myDotnetFunction;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    static async Task FunctionHandler()
    {
        var lambdaClient = new AmazonLambdaClient();
        Console.WriteLine("We got this working!");
        var response = await lambdaClient.ListFunctionsAsync();
        response.Functions.ForEach(function => {
            Console.WriteLine($"Function Name: {function.FunctionName}");
            Console.WriteLine($"Function RunTime: {function.Runtime}");
        });
        Console.WriteLine("Complete Response Object Below");
        Console.WriteLine(response);
    }
}
