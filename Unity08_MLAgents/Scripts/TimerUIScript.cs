using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIScript : MonoBehaviour
{
    public Slider slider;
    public HideAndSeekEnviroment env;

    void FixedUpdate() {
        float value = (float)env.GetResetTimer() / env.MaxEnvironmentSteps;
        
        slider = this.gameObject.GetComponent<Slider>();
        slider.value = value;
    }
}
