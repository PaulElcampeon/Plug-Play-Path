using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{

    [Header("Socket Strength")]
    [SerializeField]
    public float speed;

    private bool isTriggered;
    private bool isOccupied;

    private GameObject ball;

    private void Update()
    {
        if (ball.transform.position == transform.position) isOccupied = true;
    }

    private void FixedUpdate()
    {
        if (isTriggered && !isOccupied) ball.GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards(ball.transform.position, transform.position, this.speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOccupied && other.gameObject.tag == "Ball")
        {
            ball = other.gameObject;
            isTriggered = true;
        }
    }
}
