using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] magnets;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    public void UpdateActiveBall(GameObject ball)
    {
        foreach (GameObject magnet in magnets)
        {
            if (magnet.GetInstanceID() != gameObject.GetInstanceID())
            {
                magnet.GetComponent<Magnet>().activeBall = ball;
            }
        }
    }
}
