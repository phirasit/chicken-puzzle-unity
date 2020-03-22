using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public DoorController door;
    public bool active;
    public ClosetController closet;


    // Start is called before the first frame update
    void Start()
    {
        this.active = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.active && collision.gameObject.tag == "Player")
        {
            if (closet) closet.Toggle();
            if (door) door.Activate();
            Destroy(gameObject);
        }
    }
}
