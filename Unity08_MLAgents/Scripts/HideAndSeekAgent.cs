using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;

public class HideAndSeekAgent : Agent
{
    public Team team;

    public GameObject enemy;
    
    public HideAndSeekEnviroment hideAndSeekEnviroment;

    private float lateralSpeed;
    private float forwardSpeed;

    private Rigidbody agentRb;
    private Rigidbody enemyRb;
    private float existencialReward;

    private EnvironmentParameters resetParams;
    private HideAndSeekSettings hideAndSeekSettings;

    public override void Initialize() {
        agentRb = GetComponent<Rigidbody>();
        enemyRb = enemy.GetComponent<Rigidbody>();

        lateralSpeed = 0.3f;
        forwardSpeed = 1.3f;
        existencialReward = 1f / hideAndSeekEnviroment.MaxEnvironmentSteps;

        resetParams = Academy.Instance.EnvironmentParameters;
        hideAndSeekSettings = FindObjectOfType<HideAndSeekSettings>();
    }

    public void MoveAgent(ActionSegment<int> act) {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        var forwardAxis = act[0];
        var rightAxis = act[1];
        var rotateAxis = act[2];

        switch (forwardAxis) {
            case 1:
                dirToGo = this.transform.forward * forwardSpeed;
                break;
            case 2:
                dirToGo = this.transform.forward * -forwardSpeed;
                break;
        }

        switch (rightAxis) {
            case 1:
                dirToGo = this.transform.right * lateralSpeed;
                break;
            case 2:
                dirToGo = this.transform.right * -lateralSpeed;
                break;
        }

        switch (rotateAxis) {
            case 1:
                rotateDir = this.transform.up * -1f;
                break;
            case 2:
                rotateDir = this.transform.up * 1f;
                break;
        }

        transform.Rotate(rotateDir, Time.deltaTime * 100f);
        agentRb.AddForce(dirToGo * hideAndSeekSettings.agentRunSpeed,
            ForceMode.VelocityChange);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers) {
        if (team == Team.Blue) {
            AddReward(-existencialReward);
        } else if (team == Team.Purple) {
            AddReward(existencialReward);
        }
        MoveAgent(actionBuffers.DiscreteActions);
    }

    public override void CollectObservations(VectorSensor sensor) {
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(enemy.transform.localPosition - this.transform.localPosition);

        sensor.AddObservation(new Vector2(agentRb.velocity.x, agentRb.velocity.z));
        sensor.AddObservation(new Vector2(enemyRb.velocity.x, enemyRb.velocity.z));
    }

    public override void Heuristic(in ActionBuffers actionsOut) {
        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.W)) {
            discreteActionsOut[0] = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            discreteActionsOut[0] = 2;
        }
        if (Input.GetKey(KeyCode.A)) {
            discreteActionsOut[2] = 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            discreteActionsOut[2] = 2;
        }
        if (Input.GetKey(KeyCode.E)) {
            discreteActionsOut[1] = 1;
        }
        if (Input.GetKey(KeyCode.Q)) {
            discreteActionsOut[1] = 2;
        }
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("purpleAgent") && this.gameObject.CompareTag("blueAgent")) {
            hideAndSeekEnviroment.AgentTouched();
        }
        if (collision.gameObject.CompareTag("blueAgent") && this.gameObject.CompareTag("purpleAgent")) {
            hideAndSeekEnviroment.AgentTouched();
        }
    }

    public override void OnEpisodeBegin() {
        
    }
}