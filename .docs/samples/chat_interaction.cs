/// <summary>
/// Simulates chat interaction and returns the response from the chatbot based on the message.
/// </summary>
/// <param name="message">The message to interact with the chatbot.</param>
/// <returns>The response from the chatbot as a string.</returns>
[FunctionName("ChatActivity")]
public static string ChatInteraction([ActivityTrigger] string message)
{
    // Simulate chat interaction
    // Return the response from the chatbot based on the message
    return "Response to: " + message;
}
}

