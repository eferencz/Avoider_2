using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Transform Player;

    public PatrollerScript Skeleton;

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
    }

    void FindPlayer()
    {

        float dist = Vector3.Distance(Player.position, transform.position);

        while (dist <= 0.8)
        {

            transform.position = Vector2.MoveTowards(transform.position,
                   Player.transform.position, Skeleton.runSpeed * Time.deltaTime);
        }
    }
}
