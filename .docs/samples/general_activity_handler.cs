[FunctionName("GeneralActivityHandler")]
public static string HandleActivity([ActivityTrigger] string input)
{
    // Implement the logic based on input
    // Example: API call to verify or modify data
    return "Processed data based on input: " + input;
}
