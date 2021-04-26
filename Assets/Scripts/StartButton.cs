using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject ButtonStart;

    public GameObject ButtonQuit;

    public GameObject Player;

    void Start()
    {
        ButtonStart.SetActive(true);

        Player.SetActive(false);
    }

    public void HideStartButton()
    {
        ButtonStart.SetActive(false);
    }

    public void OnClick()
    {
        HideStartButton();

        ButtonQuit.SetActive(true);

        Player.SetActive(true);

    }

}