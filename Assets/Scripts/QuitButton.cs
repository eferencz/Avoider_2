using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject ButtonQuit;

    public GameObject Player;

    public GameObject ButtonStart;

    public PlayerController speed;

    void Start()
    {
        ButtonQuit.SetActive(false);
    }

    public void RevealQuitButton()
    {
        ButtonQuit.SetActive(true);
    }

    public void OnClick()
    {

        print("You Have Quit the Game!");

        Application.Quit();

        ResetPlayer();

        ButtonStart.SetActive(true);
    }

    public void ResetPlayer()
    {
        Player.transform.position = new Vector3(-3, -2, 0);

        Player.SetActive(false);

    }

}