using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public GameObject Key;

    public Text text;

    public bool KeyCollected = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Key.SetActive(false);

            text.color = Color.green;

            KeyCollected = true;
        }
    }
}
