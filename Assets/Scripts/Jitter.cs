using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Jitter : MonoBehaviour
{
    [SerializeField]
    private bool isAgameObject;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float minDistanceBetweenPoints = 1f;

    private Vector2 targetPosition;
    private Vector2 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        AssignTargetPositon();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < minDistanceBetweenPoints) AssignTargetPositon();
    }

    private void AssignTargetPositon()
    {
        float xPosition;
        float yPosition;

        if (isAgameObject)
        {
            xPosition = Random.Range(-0.1f, 0.1f);
            yPosition = Random.Range(-0.1f, 0.1f);
        } else
        {
            xPosition = Random.Range(-5f, 5f);
            yPosition = Random.Range(-5f, 5f);
        }

        targetPosition = new Vector2(startPosition.x + xPosition, startPosition.y + yPosition);
    }
}
