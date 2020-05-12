using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{

    [Header("Magnet Button")]
    [SerializeField]
    private Button magnetSwitch;

    [Header("Magnet Strength")]
    [SerializeField]
    public float speed;

    private bool isActive;
    private GameObject[] magnets;

    void Start()
    {
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
        TurnButtonRed();
    }

    void FixedUpdate()
    {
        if (isActive) Ball.instance.gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector3.MoveTowards(Ball.instance.gameObject.transform.position, transform.position, this.speed * Time.deltaTime));
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
        ColorBlock buttonColors = magnetSwitch.colors;
        buttonColors.normalColor = new Color32(169, 255, 76, 255);
        buttonColors.highlightedColor = new Color32(141, 241, 35, 255);
        buttonColors.selectedColor = new Color32(169, 255, 76, 255);
        magnetSwitch.colors = buttonColors;
    }

    private void TurnButtonRed()
    {
        ColorBlock buttonColors = magnetSwitch.colors;
        buttonColors.normalColor = new Color32(255, 76, 76, 255);
        buttonColors.highlightedColor = new Color32(248, 11, 11, 255);
        buttonColors.selectedColor = new Color32(255, 76, 76, 255);
        magnetSwitch.colors = buttonColors;
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
}
