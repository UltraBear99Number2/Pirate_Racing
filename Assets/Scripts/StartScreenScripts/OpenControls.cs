using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenControls : MonoBehaviour
{
    public Text TextField;

    public void SetText(string text)
    {
        TextField.text = "The controls for this game are very simple." +
            "Use WASD to move and go through the track, make sure to move along the designated path so you can hit all three checkpoints";
    } 
}
