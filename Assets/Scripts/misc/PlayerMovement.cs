using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject boat;
    public float Speed = 5f;
    public float tiger = 27f;
    public float powerSpeed = 20f;
    Animator anim;
    public bool running = false;
    public bool canMove = true;
    public float _rotationSpeed = 50f;
    bool speeding = false;
    private Rigidbody rigid;


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
        rigid = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        checkpointonetxt.enabled = false;
        checkpointtwotxt.enabled = false;
        checkpointthreetxt.enabled = false;
       

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
    private void Update()
    {
        if (istexton == true)
        {
            Invoke("DisableText", 5f);
        }
        if(cpet2 == true)
        {
            Invoke("DisableText2", 5f);
        }
        if(cpet3 == true)
        {
            Invoke("DisableText3", 5f);
        }
        if(FinishLineTrue == true)
        {
            SceneManager.LoadScene(0);
        }
        if(ext1 == true && ext2 == true)
        {
            checkpointtwotxt.enabled = false;
        }
        
    }
    
    void FixedUpdate()
    {

        if (canMove)
        {
            Vector3 move;
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0, horizontal * _rotationSpeed * Time.deltaTime, 0);
            Vector3 forward = new Vector3(0, 0, transform.position.z + vertical);
            if (speeding)
            {
                move = transform.position + (transform.forward * powerSpeed * Time.deltaTime);
            }
            else
            {
                move = transform.position + (transform.forward * Speed * Time.deltaTime);
            }

            transform.Rotate(rotation);
            rigid.MovePosition(move);
            if (move != Vector3.zero)
            {
                running = true;
            }
            else
            {
                running = false;
            }
            //anim.SetBool("isRunning", running);
        }

    }

    // THE SPEED BOASTERS
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("wahhh");
        if (other.gameObject.tag == "boaster")
        {
            Debug.Log("givemethepower");
            Speed = 40f;
        }
        if (other.gameObject.tag == "floor")
        {
            Debug.Log("takethepower");
            Speed = 20f;
        }
        if (other.gameObject.tag == "bankai")
        {
            Debug.Log("givemealittlepower");
            Speed = 30f;
        }
        if (other.gameObject.tag == "WALLS")
        {
            Vector3 move;
            float vertical = Input.GetAxis("Vertical");
            move = Vector3.back * tiger * Time.deltaTime * vertical;        
        }
        if(other.gameObject.tag == "checkpoint")
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
        if(checkpointone == true && checkpointtwo == true && checkpointthree == true)
        {
            Debug.Log("all checkpoints hit");
            allcheckpointstrue = true;

        }
        if(other.gameObject.tag == "startline" && allcheckpointstrue == true)
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
    public void speedUp()
    {
        //Debug.Log("asdfghujik");
        //Speed = 20f;
        speeding = true;
        //Debug.Log(speeding);
    }
    public void slowDown()
    {
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaasdfghujik");
        //Speed = 7f;
        speeding = false;
    }
}