﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    private bool isActive;
    private GameObject[] magnets;
    private GameObject[] balls;
    private CircleCollider2D collider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
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
            balls = GameObject.FindGameObjectsWithTag("Ball");

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

    public void Deactivate()
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
                magnet.GetComponent<Switch>().Deactivate();
            }
        }
    }

    private void CheckForTouch()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPosition = new Vector2(wp.x, wp.y);

                if (collider == Physics2D.OverlapPoint(touchPosition))
                {
                    Hit();
                }
            }
        }

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 touchPosition = new Vector2(wp.x, wp.y);

                if (collider == Physics2D.OverlapPoint(touchPosition))
                {
                    Hit();
                }
            }
        }
    }
}
