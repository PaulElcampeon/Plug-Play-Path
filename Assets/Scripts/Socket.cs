using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{

    [Header("Socket Strength")]
    [SerializeField]
    public float speed;

    public int colourNo { get; set; }

    private bool isTriggered;
    private bool isOccupied;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private GameObject ball;

    private void Update()
    {
        if (!isTriggered) return;

        if (Vector2.Distance(ball.transform.position, transform.position) < 0.01)
        {
            ball.GetComponent<Ball>().Socketed();

            if (colourNo == ball.GetComponent<Ball>().colourNo)
            {
                isOccupied = true;

                if (CheckIfAllSocketsAreOccupied()) GameUIManager.instance.OpenNextPanel();
            }
            else
            {
                isTriggered = false;

                ball.GetComponent<Ball>().Dissapear();

                GameUIManager.instance.OpenRetryPanel();
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
            if (other.gameObject.GetComponent<Ball>().isGoingIntoSocket) return;

            isTriggered = true;
            ball = other.gameObject;
            ball.GetComponent<Ball>().isGoingIntoSocket = true;

            if (ball.GetComponent<Ball>().colourNo != colourNo) ball.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void SetColour(Color colour)
    {
        spriteRenderer.color = colour;
    }

    public bool CheckIfAllSocketsAreOccupied()
    {
        GameObject[] sockets = GameObject.FindGameObjectsWithTag("Socket");

        foreach (GameObject socket in sockets)
        {
            if (!socket.GetComponent<Socket>().isOccupied) return false;
        }

        return true;
    }
}
