using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{

    [Header("Socket Strength")]
    [SerializeField]
    public float speed;

    [Header("Attributes")]
    [SerializeField]
    private string givenColour;

    private bool isTriggered;
    private bool isOccupied;

    private GameObject ball;

    private void Update()
    {
        if (!isTriggered) return;

        if (Vector2.Distance(ball.transform.position, transform.position) < 0.01)
        {
            ball.GetComponent<Ball>().Socketed();

            if (givenColour == ball.GetComponent<Ball>().colour)
            {
                isOccupied = true;
            }
            else
            {
                isTriggered = false;

                ball.GetComponent<Ball>().Dissapear();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isTriggered && !isOccupied) ball.GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards(ball.transform.position, transform.position, this.speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOccupied) return;

        if (!isTriggered && other.gameObject.tag == "Ball")
        {
            isTriggered = true;
            ball = other.gameObject;
            ball.GetComponent<Ball>().isGoingIntoSocket = true;
            if (ball.GetComponent<Ball>().colour != givenColour) ball.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
