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

    [SerializeField]
    private GameObject westSwtiches;

    [SerializeField]
    private GameObject eastSwtiches;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Game") return;

        float aspectRatio = Camera.main.aspect;


        if (aspectRatio == 16f / 9f)
        {
            sixteenByNine.SetActive(true);

            westSwtiches.transform.position = new Vector3(-0.57f, 0, 0);
            eastSwtiches.transform.position = new Vector3(0.51f, 0, 0);

            Debug.Log("16by9");
        }
        else if (aspectRatio == 19f / 9f)
        {
            nineteenByNine.SetActive(true);

            westSwtiches.transform.position = new Vector3(-2.1f, 0, 0);
            eastSwtiches.transform.position = new Vector3(2.21f, 0, 0);

            Debug.Log("19by9");
        }
        else if (aspectRatio == 18f / 9f)
        {
            eighteenByNine.SetActive(true);

            westSwtiches.transform.position = new Vector3(-1.62f, 0, 0);
            eastSwtiches.transform.position = new Vector3(1.63f, 0, 0);

            Debug.Log("18by3");

        }
        else if (aspectRatio == 5f / 3f)
        {
            fiveByThree.SetActive(true);

            westSwtiches.transform.position = Vector3.zero;
            eastSwtiches.transform.position = Vector3.zero;

            Debug.Log("5by3");
        }
        else if (aspectRatio == 37f / 18f)
        {
            thirtySevenByEighteen.SetActive(true);

            westSwtiches.transform.position = new Vector3(-1.82f, 0 , 0);
            eastSwtiches.transform.position = new Vector3(1.92f, 0, 0);

            Debug.Log("37by18");
        }
        else
        {
            sixteenByNine.SetActive(true);

            westSwtiches.transform.position = new Vector3(-0.57f, 0, 0);
            eastSwtiches.transform.position = new Vector3(0.51f, 0, 0);
        }
    }
}
