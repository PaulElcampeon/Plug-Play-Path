using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int colourNo { get; set; }
    public bool isSocketed { get; set; }
    public bool isGoingIntoSocket { get; set; }
    public float speed;
    private bool shouldDissapear;
    private bool canMakeSound = true;


    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (shouldDissapear) Minify();
    }

    public void Socketed()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        isSocketed = true;
    }

    public void Dissapear()
    {
        shouldDissapear = true;

        Invoke("Disable", 2f); 
    }

    private void Minify()
    {
        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * 0.8f, gameObject.transform.localScale.y * 0.8f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SetColour(Color colour)
    {
        spriteRenderer.color = colour;
    }

    //public void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (!canMakeSound) return;

    //    if (other.gameObject.tag == "Ball" /*||other.gameObject.tag == "Magnet"*/)
    //    {
    //        StartCoroutine(ResetSound());

    //        SoundManager.instance.PlaySFX(0);
    //    }
    //}

    //private IEnumerator ResetSound()
    //{
    //    canMakeSound = false;
    //    yield return new WaitForSeconds(1f);
    //    canMakeSound = true;
    //}
}
