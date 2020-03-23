using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    public GameObject door;
    public PredatorController predator;
    public GameObject predatorHealthBar;

    protected bool isOpened = false;


    private void Start()
    {
        predatorHealthBar.SetActive(false);
    }

    public void Toggle()
    {
        isOpened = !isOpened;
        door.SetActive(!isOpened);
        if (predatorHealthBar) predatorHealthBar.SetActive(true);
        if (predator)
        {
            predator.active = true;
        }
    }
}