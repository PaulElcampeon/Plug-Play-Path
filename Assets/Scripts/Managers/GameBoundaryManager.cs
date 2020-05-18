using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameBoundaryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nineteenByNine;

    [SerializeField]
    private GameObject sixteenByNine;

    [SerializeField]
    private GameObject eighteenByNine;

    [SerializeField]
    private GameObject fiveByThree;

    [SerializeField]
    private GameObject thirtySevenByEighteen;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Game") return;

        float aspectRatio = Camera.main.aspect;

        if (aspectRatio == 16f / 9f)
        {
            sixteenByNine.SetActive(true);
            Debug.Log("16by9");

        }
        else if (aspectRatio == 19f / 9f)
        {
            nineteenByNine.SetActive(true);
            Debug.Log("19by9");

        }
        else if (aspectRatio == 18f / 9f)
        {
            eighteenByNine.SetActive(true);
            Debug.Log("18by3");

        }
        else if (aspectRatio == 5f / 3f)
        {
            fiveByThree.SetActive(true);
            Debug.Log("5by3");
        }
        else if (aspectRatio == 37f / 18f)
        {
            thirtySevenByEighteen.SetActive(true);
            Debug.Log("37by18");
        }
        else
        {
            sixteenByNine.SetActive(true);
        }
    }
}
