using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectRandomPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> powerupList;
    public int randomNumberInList;
    public GameObject chosenPowerup;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "itemboxes")
        {
            randomNumberInList = Random.Range(0, powerupList.Count);
            chosenPowerup = powerupList[randomNumberInList];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && chosenPowerup)
        {
            Instantiate(chosenPowerup, transform.position + new Vector3(0, 1 / 2, -2), transform.rotation);
            chosenPowerup = null;
        }
    }
}
