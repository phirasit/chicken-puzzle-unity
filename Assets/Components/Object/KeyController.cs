using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject door;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        this.active = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.active && collision.gameObject.tag == "Player") {
            Destroy(door);
            Destroy(gameObject);
        }
    }
}
