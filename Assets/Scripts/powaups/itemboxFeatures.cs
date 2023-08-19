using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemboxFeatures : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 600f;
    float movement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 50f);

    }
    private void itemBoxRespawn()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Invoke("itemBoxRespawn", 2.0f);
        gameObject.SetActive(false);
    }
}
