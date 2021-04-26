using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed = 1f;

    public float numberClicks = 0;

    private Vector3 goal;
    private float doubleClickTimer = 0.25f;

    void Start()
    {
        goal = transform.position;
    }

    void Update()
    {
        Vector3 mouseInSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            StartCoroutine(MoveTo(transform.position, mouseInSpace, runSpeed));
        }
    }

    IEnumerator MoveTo(Vector3 start, Vector3 destination, float speed)
    {
        while ((transform.position - destination).sqrMagnitude > 0.01f)
        {
            StartCoroutine(ClickTracker());
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ClickTracker()
    {
        while (enabled)
        {
            while (Time.deltaTime < doubleClickTimer)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    numberClicks += 1;
                }

                if (numberClicks == 1)
                {
                    StartCoroutine(WaitForSecondClick());
                }

                if (numberClicks == 2)
                {
                    yield return StartCoroutine(SpeedBoost());
                }
                else
                {
                    yield return null;
                }
            }
        }
    }


    private IEnumerator WaitForSecondClick()
    {
        yield return new WaitForSeconds(0.25f);
        numberClicks = 0;
    }

    private IEnumerator SpeedBoost()
    {
        numberClicks = 0;
        runSpeed = 2f;
        yield return new WaitForSeconds(1.5f);
        runSpeed = 1f;
    }


}


