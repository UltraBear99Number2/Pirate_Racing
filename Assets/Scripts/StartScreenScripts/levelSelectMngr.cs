using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelSelectMngr : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TextSpace;
    public void SetText(string text)
    {
        TextSpace.text = "Select a lvl";
    }
}
