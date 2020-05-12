using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public void UpdateActiveBall()
    {
        GameManager.instance.UpdateActiveBall(gameObject);
    }

    public void Socketed()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
