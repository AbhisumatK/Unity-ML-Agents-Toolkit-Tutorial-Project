using UnityEngine;
using Unity.MLAgents;

public class MoveToBallAgent : Agent
{
    public override void OnActionReceived(ActionBuffers actions)
    {
        // Implement the logic to move the agent towards the ball based on the received actions
        Debug.Log(actions.DiscreteActions[0]); // Example: Log the first discrete action received
    }
    
}
