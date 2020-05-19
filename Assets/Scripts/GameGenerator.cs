using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject switchButtonReference;

    [SerializeField]
    private GameObject ballReference;

    [SerializeField]
    private GameObject socketReference;

    [SerializeField]
    private float minXPosBall;

    [SerializeField]
    private float maxXPosBall;

    [SerializeField]
    private float minYPosBall;

    [SerializeField]
    private float maxYPosBall;

    [SerializeField]
    private float minDistanceBetweenBalls;

    [SerializeField]
    private float minXPosSwitch;

    [SerializeField]
    private float maxXPosSwitch;

    [SerializeField]
    private float minYPosSwitch;

    [SerializeField]
    private float maxYPosSwitch;

    [SerializeField]
    private float minDistanceBetweenSockets;

    private List<GameObject> balls = new List<GameObject>();
    private List<GameObject> sockets = new List<GameObject>();

    //Dictionary<int, Color> ColoursUsed = new Dictionary<int, Color>();

    private int minBalls;
    private int maxBalls;
    private int minSockets;
    private int maxSockets;
    private float minSpeed;
    private float maxSpeed;

    public static GameGenerator instance;

    private void Start()
    {
        //ColoursUsed.Add(0, Color.blue);
        //ColoursUsed.Add(1, Color.magenta);
        //ColoursUsed.Add(2, Color.yellow);
        //ColoursUsed.Add(3, Color.red);
        //ColoursUsed.Add(4, Color.cyan);

        UpdateDifficultyLevel(GameManager.instance.difficulty);
        //UpdateDifficultyLevel(3);
    }

    public void Generate()
    {
        ClearMap();
        ClearLists();

        ResetSwitches();

        int noOfBallsToCreate = Random.Range(minBalls, maxBalls + 1);

        int noOfSocketsToCreate = Random.Range(minSockets, maxSockets + 1);

        if (noOfBallsToCreate < noOfSocketsToCreate) noOfSocketsToCreate = noOfBallsToCreate;

        Color color = Color.red;

        for (int i = 0; i < noOfBallsToCreate; i++)
        {

            if (i > noOfSocketsToCreate)
            {
            } else
            {
                color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            }

            Vector3 ballPosition = FindAvailablePositionForBall();

            GameObject ball = Instantiate(ballReference, ballPosition, Quaternion.identity);

            //Color color;
            //if (ColoursUsed.TryGetValue(i, out color))
            //{
            //}

            ball.GetComponent<Ball>().SetColour(color);

            if (i > noOfSocketsToCreate)
            {
                ball.GetComponent<Ball>().colourNo = i - 1;
            }
            else
            {
                ball.GetComponent<Ball>().colourNo = i;
            }

            ball.GetComponent<Ball>().speed = Random.Range(minSpeed, maxSpeed);
            
            balls.Add(ball);

            if (i <= noOfSocketsToCreate) {
                Vector3 socketPosition = FindAvailablePositionForSocket();

                GameObject socket = Instantiate(socketReference, socketPosition, Quaternion.identity);

                socket.GetComponent<Socket>().SetColour(color);
                socket.GetComponent<Socket>().colourNo = i;

                sockets.Add(socket);
            }
        }
    }

    private void ResetSwitches()
    {
        GameObject[] switches = GameObject.FindGameObjectsWithTag("Magnet");

        foreach (GameObject switchObj in switches)
        {
            switchObj.GetComponent<Switch>().Deactivate();
        }
    }

    public void ClearLists()
    {
        balls.Clear();
        sockets.Clear();
    }

    private void ClearMap()
    {
        foreach (GameObject ball in balls) Destroy(ball);
        foreach (GameObject socket in sockets) Destroy(socket);
    }

    private Vector3 FindAvailablePositionForBall() //Find positions for balls before sockets
    {
        bool stillLookingForPosition = true;

        Vector3 possiblePosition = Vector3.zero;

        while (stillLookingForPosition)
        {
            stillLookingForPosition = false;

            float xPos = Random.Range(minXPosBall, maxXPosBall);
            float yPos = Random.Range(minYPosBall, maxYPosBall);

            possiblePosition = new Vector3(xPos, yPos, 0);

            foreach(GameObject ball in balls)
            {
                if(Vector2.Distance(ball.transform.position, possiblePosition) < minDistanceBetweenBalls)
                {
                    stillLookingForPosition = true;
                }
            }

            foreach (GameObject socket in sockets)
            {
                if (Vector2.Distance(socket.transform.position, possiblePosition) < minDistanceBetweenBalls)
                {
                    stillLookingForPosition = true;
                }
            }
        }

        return possiblePosition;
    }

    private Vector3 FindAvailablePositionForSocket() //Find positions for sockets after balls
    {
        bool stillLookingForPosition = true;

        Vector3 possiblePosition = Vector3.zero;

        while (stillLookingForPosition)
        {
            stillLookingForPosition = false;

            float xPos = Random.Range(minXPosSwitch, maxXPosSwitch);
            float yPos = Random.Range(minYPosSwitch, maxYPosSwitch);

            possiblePosition = new Vector3(xPos, yPos, 0);

            foreach (GameObject ball in balls)
            {
                if (Vector2.Distance(ball.transform.position, possiblePosition) < minDistanceBetweenSockets)
                {
                    stillLookingForPosition = true;
                }
            }

            foreach (GameObject socket in sockets)
            {
                if (Vector2.Distance(socket.transform.position, possiblePosition) < minDistanceBetweenSockets)
                {
                    stillLookingForPosition = true;
                }
            }
        }

        return possiblePosition;
    }

    public void UpdateDifficultyLevel(int difficultyLevel)
    {

        if (difficultyLevel == 1)
        {
            minBalls = 2;
            maxBalls = 4;
            minSockets = 2;
            maxSockets = 4;
            minSpeed = 1f;
            maxSpeed = 5f;

        } else if (difficultyLevel == 2)
        {
            minBalls = 2;
            maxBalls = 4;
            minSockets = 2;
            maxSockets = 4;
            minSpeed = 1f;
            maxSpeed = 9f;

        } else
        {
            minBalls = 3;
            maxBalls = 5;
            minSockets = 3;
            maxSockets = 5;
            minSpeed = 1f;
            maxSpeed = 12f;
        }
    }
}
