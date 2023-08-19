using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject boat;
    public float Speed = 20.0F;
    public float rotateSpeed = 3F;

    public bool checkpointone = false;
    public bool checkpointtwo = false;
    public bool checkpointthree = false;

    public bool allcheckpointstrue = false;

    public bool FinishLineTrue = false;
    public Text checkpointonetxt;
    public Text checkpointtwotxt;
    public Text checkpointthreetxt;


    public bool istexton = false;
    public bool cpet2 = false;
    public bool cpet3 = false;


    public bool ext1 = false;
    public bool ext2 = false;
    
    void Start()
    {
        checkpointonetxt.enabled = false;
        checkpointtwotxt.enabled = false;
        checkpointthreetxt.enabled = false;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = Speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        if (istexton == true)
        {
            Invoke("DisableText", 5f);
        }
        if (cpet2 == true)
        {
            Invoke("DisableText2", 5f);
        }
        if (cpet3 == true)
        {
            Invoke("DisableText3", 5f);
        }
        if (FinishLineTrue == true)
        {
            SceneManager.LoadScene(0);
        }
        if (ext1 == true && ext2 == true)
        {
            checkpointtwotxt.enabled = false;
        }


    }
    void cpe2()
    {
        checkpointtwotxt.enabled = true;

        cpet2 = true;
        ext1 = true;
    }
    void cpe3()
    {
        checkpointthreetxt.enabled = true;

        cpet3 = true;
        ext2 = true;
    }
    void enabletext()
    {
        checkpointonetxt.enabled = true;

        istexton = true;
        Debug.Log("whosowen");
    }
    void DisableText()
    {
        checkpointonetxt.enabled = false;

    }
    void DisableText2()
    {
        checkpointtwotxt.enabled = false;

    }
    void DisableText3()
    {
        checkpointthreetxt.enabled = false;

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("wahhh");
        if (other.gameObject.tag == "boaster")
        {
            Debug.Log("givemethepower");
            Speed = 27f;
        }
        if (other.gameObject.tag == "floor")
        {
            Debug.Log("takethepower");
            Speed = 9f;
        }
        if (other.gameObject.tag == "bankai")
        {
            Debug.Log("givemealittlepower");
            Speed = 18f;
        }
        if (other.gameObject.tag == "checkpoint")
        {
            checkpointone = true;
            Debug.Log("checkpointone hit");
            Invoke("enabletext", 0f);

        }
        if (other.gameObject.tag == "checkpointdos")
        {
            checkpointtwo = true;
            Debug.Log("checkpointtwo hit");
            Invoke("cpe2", 0f);
        }
        if (other.gameObject.tag == "checkpointtres")
        {
            checkpointthree = true;
            Debug.Log("checkpointthree hit");
            Invoke("cpe3", 0f);
        }
        if (checkpointone == true && checkpointtwo == true && checkpointthree == true)
        {
            Debug.Log("all checkpoints hit");
            allcheckpointstrue = true;

        }
        if (other.gameObject.tag == "startline" && allcheckpointstrue == true)
        {
            Debug.Log("level won");
            FinishLineTrue = true;
        }
        if (other.gameObject.tag == "gt2" && allcheckpointstrue == true)
        {
            SceneManager.LoadScene(4);
        }
        if (other.gameObject.tag == "gt3" && allcheckpointstrue == true)
        {
            SceneManager.LoadScene(5);
        }
    }
}
