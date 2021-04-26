using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerScript : MonoBehaviour
{

    public GameObject Door;

    public KeyScript Silver;
    public KeyScript Gold;

    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForKeys();
    }

    void CheckForKeys()
    {
        if (Silver.KeyCollected && Gold.KeyCollected)
        {
            Door.SetActive(false);
        }
        else
        {
            Door.SetActive(true);
        }
    }
}
