using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Move : Agent
{
    [SerializeField] private Transform target1Transform;
    [SerializeField] private Transform target2Transform;
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target1Transform.position);
        sensor.AddObservation(target2Transform.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log(actions.DiscreteActions[0]);
        float Jump = actions.DiscreteActions[0];
        float jumpForce = 10f;
        transform.position += new Vector3(0, Time.deltaTime * jumpForce, 0);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SetReward(-1f / MaxStep);
            EndEpisode();
        }
    }
}
