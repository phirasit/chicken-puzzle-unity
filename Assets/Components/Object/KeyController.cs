using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public DoorController door;
    public bool active;
    public ClosetController closet;
    public GameObject predatorHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        this.active = true;
        predatorHealthBar.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.active && collision.gameObject.tag == "Player") {
            if (closet) closet.Toggle();
            if (door) door.Activate();
            if (predatorHealthBar) predatorHealthBar.SetActive(true);
            Destroy(gameObject);
        }
    }
}
