using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    private bool isActive;
    private GameObject[] magnets;
    private GameObject[] balls;
    private CircleCollider2D collider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        balls = GameObject.FindGameObjectsWithTag("Ball");
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
        TurnButtonRed();
    }

    private void Update()
    {
        CheckForTouch();
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            foreach (GameObject gameObject in balls)
            {
                if (gameObject.GetComponent<Ball>().isGoingIntoSocket) continue;

                gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards(gameObject.transform.position, transform.position, gameObject.GetComponent<Ball>().speed * Time.deltaTime));
            }
        }
    }

    public void Hit()
    {

        if (this.isActive)
        {
            this.Deactivate();
        }
        else
        {
            this.Activate();
        }
    }

    private void Activate()
    {
        DeactivateAllOtherMagnets();
        TurnButtonGreen();
        this.isActive = true;
    }

    private void TurnButtonGreen()
    {
        spriteRenderer.color = new Color32(169, 255, 76, 255);
    }

    private void TurnButtonRed()
    {
        spriteRenderer.color = new Color32(255, 76, 76, 255);
    }

    private void Deactivate()
    {
        TurnButtonRed();
        this.isActive = false;
    }

    private void DeactivateAllOtherMagnets()
    {
        foreach(GameObject magnet in magnets)
        {
            if (magnet.GetInstanceID() != gameObject.GetInstanceID())
            {
                magnet.GetComponent<Magnet>().Deactivate();
            }
        }
    }

    private void CheckForTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (collider == Physics2D.OverlapPoint(touchPosition))
            {
                Hit();
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{

        //    var wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    var touchPosition = new Vector2(wp.x, wp.y);

        //    if (collider == Physics2D.OverlapPoint(touchPosition))
        //    {
        //        Hit();
        //    }
        //}
    }
}
