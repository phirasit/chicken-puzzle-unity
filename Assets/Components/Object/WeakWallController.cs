using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakWallController : MonoBehaviour
{
    // Start is called before the first frame update
    public ChickenController player;
    public float WallHP = 5;
    private float dist;
    private float minDist = 1.0f;
    private string text = "This wall can be breakable.";

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        // if (hit on wall){
        //  WallHP-= damage of chicken or something
        // }
        // if (wallHP <= 0) {
            //break wall
        // }
    }
    void OnGUI()
    {
        if (dist <= minDist) return
        GUI.TextArea(new Rect(100, 50, 200, 100), text);
    }
}
