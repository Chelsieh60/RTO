using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Button instructionButton;
    public Text needsHelp;
    public Button next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartInstructions()
    {
        instructionButton.enabled = false;
        //needsHelp.enabled = true;
        //next.enabled = true;
    }
}
