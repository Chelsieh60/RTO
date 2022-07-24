using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject chat;
    public GameObject lost;
    public GameObject text1;
    public GameObject text2;

    public Button dog;
    public Button cat;
    public Button idk;
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text2.activeInHierarchy)
        {
            yes.enabled = true;
            no.enabled = true;
        }
    }
    public void Chat()
    {
        mainMenu.SetActive(false);
        chat.SetActive(true);
        text1.SetActive(true);
        dog.enabled = true;
        cat.enabled = true;
        idk.enabled = true;
    }
    public void Animal()
    {
        text2.SetActive(true);
        yes.enabled = true;
        no.enabled = true;
    }
    public void ChatBack()
    {
        chat.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ARTraining()
    {
        SceneManager.LoadScene("ARGame");

    }
    public void Lost()
    {
        lost.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LostBack()
    {
        lost.SetActive(false);
        mainMenu.SetActive(true);
    }

}
