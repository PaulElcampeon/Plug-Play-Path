using System.Collections;
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
    private bool canShatter = true;

    [SerializeField]
    private GameObject shatterYellow;

    [SerializeField]
    private GameObject shatterWhite;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        balls = GameObject.FindGameObjectsWithTag("Ball");
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
        TurnButtonWhite();
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
        TurnButtonYellow();
        this.isActive = true;
    }

    private void TurnButtonYellow()
    {
        spriteRenderer.color = Color.yellow;
    }

    private void TurnButtonWhite()
    {
        spriteRenderer.color = Color.white;
    }

    public void Deactivate()
    {
        TurnButtonWhite();
        this.isActive = false;
    }

    private void DeactivateAllOtherMagnets()
    {
        foreach (GameObject magnet in magnets)
        {
            if (magnet.GetInstanceID() != gameObject.GetInstanceID())
            {
                magnet.GetComponent<Switch>().Deactivate();
            }
        }
    }

    private void Shatter()
    {
        if (isActive)
        {
            Instantiate(shatterYellow, transform.position, Quaternion.identity);
        } else
        {
            Instantiate(shatterWhite, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
          
            //SoundManager.instance.PlaySFX(4);

            if (!canShatter) return;

            Shatter();
            StartCoroutine(ResetShatter());
        }
    }

    private IEnumerator ResetShatter()
    {
        canShatter = false;
        yield return new WaitForSeconds(2f);
        canShatter = true;
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
