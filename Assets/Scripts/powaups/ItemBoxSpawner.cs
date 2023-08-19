using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxSpawner : MonoBehaviour
{
    public GameObject itemBox;

    public int numberOfBoxes;

    public int modifiyXPosition;
    public int modifiyZPosition;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBoxes; i++)
        {
            GameObject itemBoxClone = Instantiate(itemBox,
                new Vector3(
                transform.position.x + modifiyXPosition * i,
                transform.position.y,
                transform.position.z + modifiyZPosition * i
                ),
                transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
