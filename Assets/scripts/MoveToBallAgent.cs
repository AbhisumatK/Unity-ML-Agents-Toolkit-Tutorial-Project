using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Collections;
using System.Collections.Generic;

public class MoveToBallAgent : Agent
{
    [SerializeField] private Transform ballTransform; // Reference to the ball's transform
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    public override void OnEpisodeBegin()
    {
        // Reset the agent's position and the ball's position at the beginning of each episode
        transform.localPosition = new Vector3(0.9f, 0.5f, -1.34f);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Example: sensor.AddObservation(transform.position); // Add the agent's position as an observation
        sensor.AddObservation(transform.localPosition); // Add the agent's position as an observation
        sensor.AddObservation(ballTransform.localPosition); // Add the ball's position as an observation
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        // Implement the logic to move the agent towards the ball based on the received actions
        float moveX = actions.ContinuousActions[0]; // Get the horizontal movement action
        float moveZ = actions.ContinuousActions[1]; // Get the vertical movement action

        float moveSpeed = 3f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed; // Move the agent based on the actions

        
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Implement heuristic logic for testing the agent manually (optional)
        ActionSegment<float> continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal"); // Use horizontal input for movement
        continuousActionsOut[1] = Input.GetAxisRaw("Vertical"); // Use vertical input for movement
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            SetReward(+1f); // Reward the agent for reaching the ball
            floorMeshRenderer.material = winMaterial; // Change the floor material to indicate a win
            EndEpisode(); // End the episode after reaching the ball
        }
        if (other.CompareTag("wall"))
        {
            SetReward(-1f); // Reward the agent for reaching the ball
            floorMeshRenderer.material = loseMaterial; // Change the floor material to indicate a loss
            EndEpisode(); // End the episode after reaching the ball
        }
    }
}
