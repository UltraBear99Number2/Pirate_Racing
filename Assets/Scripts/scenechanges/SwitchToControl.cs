using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnButtonPress()
    {
        print("button pressed");
        SceneManager.LoadScene(2);
    }
}
