using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject swotchM;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject socket;

    public int difficulty = 2;

    public static GameGenerator instance;

    public void Generate()
    {

    }
}
