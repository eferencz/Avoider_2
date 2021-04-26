using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerScript : MonoBehaviour
{

    public List<WaypointScript> Waypoints = new List<WaypointScript>();

    public float runSpeed = 0.5f;
    public int DestinationWaypoint = 1;

    public GameObject Player;

    private Vector3 Destination;
    private bool Forwards = true;

    private float TimePassed = 0f;

    public PlayerController playerController;

    public Vector3 goal;


    void Start()
    {
        this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
    }


    void Update()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo());
    }


    IEnumerator MoveTo()
    {
        while ((transform.position - this.Destination).sqrMagnitude > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                this.Destination, this.runSpeed * Time.deltaTime);
            yield return null;
        }

        if ((transform.position - this.Destination).sqrMagnitude <= 0.01f)
        {
            if (this.Waypoints[DestinationWaypoint].IsSentry)
            {
                while (this.TimePassed < this.Waypoints[DestinationWaypoint].PauseTime)
                {
                    this.TimePassed += Time.deltaTime;
                    yield return null;
                }

                this.TimePassed = 0;
            }

            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (this.Waypoints[DestinationWaypoint].IsEndpoint)
        {
            if (this.Forwards)
                this.Forwards = false;
            else
                this.Forwards = true;
        }

        if (this.Forwards)
            ++DestinationWaypoint;
        else
            --DestinationWaypoint;

        if (DestinationWaypoint >= this.Waypoints.Count)
            DestinationWaypoint = 0;

        this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            Player.transform.position = new Vector3(-3, -2, 0);
        }
    }


}
