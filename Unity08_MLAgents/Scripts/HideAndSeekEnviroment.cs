using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgentsExamples;
using System.Collections;
using System.Collections.Generic;

public class HideAndSeekEnviroment : MonoBehaviour
{
    [System.Serializable]
    public class AgentInfo
    {
        public HideAndSeekAgent Agent;
        [HideInInspector]
        public Vector3 StartingPos;
        [HideInInspector]
        public Quaternion StartingRot;
        [HideInInspector]
        public Rigidbody Rb;
    }

    /// <summary>
    /// Max Academy steps before this platform resets
    /// </summary>
    /// <returns></returns>
    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps = 25000;

    public List<AgentInfo> AgentsList = new List<AgentInfo>();

    public Transform[] spawns;

    public GameObject obstaclesFather;
    public int nObstacles;

    public GameObject ground;

    private Renderer groundRenderer;
    private Material groundMaterial;

    private List<GameObject> obstacles_;

    private int chaserSpawnIndex_ = -1;
    private int runnerSpawnIndex_ = -1;

    private HideAndSeekSettings hideAndSeekSettings_;

    private SimpleMultiAgentGroup blueAgentGroup_;
    private SimpleMultiAgentGroup purpleAgentGroup_;

    private int resetTimer_;

    public int GetResetTimer() {
        return resetTimer_;
    }

    void Start() {
        hideAndSeekSettings_ = FindObjectOfType<HideAndSeekSettings>();
        blueAgentGroup_ = new SimpleMultiAgentGroup();
        purpleAgentGroup_ = new SimpleMultiAgentGroup();

        groundRenderer = ground.GetComponent<Renderer>();
        groundMaterial = groundRenderer.material;

        foreach (var item in AgentsList) {
            item.StartingPos = item.Agent.transform.position;
            item.StartingRot = item.Agent.transform.rotation;
            item.Rb = item.Agent.GetComponent<Rigidbody>();
            if (item.Agent.team == Team.Blue) {
                blueAgentGroup_.RegisterAgent(item.Agent);
            } else {
                purpleAgentGroup_.RegisterAgent(item.Agent);
            }
        }
        ResetScene();
    }

    void FixedUpdate() {
        Debug.Log((float)resetTimer_ / MaxEnvironmentSteps);
        resetTimer_ += 1;
        if (resetTimer_ >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0) {
            purpleAgentGroup_.AddGroupReward(1);
            blueAgentGroup_.AddGroupReward(-1);

            StartCoroutine(AgentTouchedSwapGroundMaterial(hideAndSeekSettings_.purpleMaterial, 0.5f));

            purpleAgentGroup_.EndGroupEpisode();
            blueAgentGroup_.EndGroupEpisode();
            ResetScene();
        }
    }

    IEnumerator AgentTouchedSwapGroundMaterial(Material mat, float time) {
        groundRenderer.material = mat;
        yield return new WaitForSeconds(time);
        groundRenderer.material = groundMaterial;
    }

    public void AgentTouched() {
        blueAgentGroup_.AddGroupReward(1 - (float)resetTimer_ / MaxEnvironmentSteps);
        purpleAgentGroup_.AddGroupReward(-1 + (float)resetTimer_ / MaxEnvironmentSteps);

        StartCoroutine(AgentTouchedSwapGroundMaterial(hideAndSeekSettings_.blueMaterial, 0.5f));

        purpleAgentGroup_.EndGroupEpisode();
        blueAgentGroup_.EndGroupEpisode();
        ResetScene();
    }

    public Transform GetPlayerSpawn(Team team) {
        if (team == Team.Blue) {
            chaserSpawnIndex_ = Random.Range(0, spawns.Length - 1);
            while (chaserSpawnIndex_ == runnerSpawnIndex_) {
                chaserSpawnIndex_ = Random.Range(0, spawns.Length - 1);
            }
            return spawns[chaserSpawnIndex_];
        }

        runnerSpawnIndex_ = Random.Range(0, spawns.Length - 1);
        while (chaserSpawnIndex_ == runnerSpawnIndex_) {
            runnerSpawnIndex_ = Random.Range(0, spawns.Length - 1);
        }
        return spawns[runnerSpawnIndex_];
    }

    public void SetListObstacles() {
        obstacles_ = new List<GameObject>();
        foreach (Transform childTransform in obstaclesFather.transform) {
           obstacles_.Add(childTransform.gameObject);
        }
    }

    public void DeactivateObstacles() {
        SetListObstacles();
        for (int i = 0; i < obstacles_.Count; i++) {
            obstacles_[i].SetActive(false);
        }
    }

    public void ActivateRandomObstacles() {
        DeactivateObstacles();
        int nActivated = 0;
        while (nActivated < nObstacles) {
            int activateIndex = Random.Range(0, obstacles_.Count - 1);
            if (obstacles_[activateIndex].activeSelf == false) {
                obstacles_[activateIndex].SetActive(true);
                nActivated++;
            }
        }
    }

    public void ResetScene() {
        resetTimer_ = 0;

        ActivateRandomObstacles();

        foreach (var item in AgentsList) {
            Transform newTransform = GetPlayerSpawn(item.Agent.team);
            item.Agent.transform.position = newTransform.position;
            item.Agent.transform.rotation = newTransform.rotation;

            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
        }
    }
}
