using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimerCounter : MonoBehaviour
{
    public Text lapTime;
    public Text startCountdown;

    public float totalLapTime;
    public float totalCountdownTime;

    public NewBehaviourScript boat;

    
    void Update()
    {
        if (totalLapTime >= 0 && totalLapTime < 1)
        {
            boat.Speed = 7;
        }
        if (totalCountdownTime > 0)
        {
            boat.Speed = 0b0;
            totalCountdownTime -= Time.deltaTime;
            startCountdown.text = Mathf.Round(totalCountdownTime).ToString();
        }
        if (totalCountdownTime <= 0)
        {
            startCountdown.text = "";
            totalLapTime += Time.deltaTime;
            lapTime.text = Mathf.Round(totalLapTime).ToString();
        }
        
    }

}
