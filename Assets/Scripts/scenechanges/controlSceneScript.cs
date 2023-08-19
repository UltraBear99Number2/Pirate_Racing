using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnButtonPress()
    {
        print("button pressed");
        SceneManager.LoadScene(0);
    }
}
