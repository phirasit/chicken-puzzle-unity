using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasKey = false;
    public ChickenController player;
    public float startHP;
    protected float progress; 
    public float unlockTime = 5.0f;

    private float dist;
    private float minDist = 3.0f;

    public void Activate() {
        hasKey = true;
    }

    void Start()
    {
        startHP = 0.0f;
        progress = 0.0f;
        dist = minDist + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (hasKey && dist <= minDist) {
            if (player.GetHP() != startHP) {
                progress = 0;
                startHP = player.GetHP();
            }

            progress += Time.deltaTime;
            if (progress > unlockTime) {
                Destroy(gameObject);
            }
        }
    }
    void OnGUI()
    {
        if (dist > minDist) return;
        string text;
        if (!hasKey) {
            text = "Find Key";
        } else {
            text = string.Format("Opening Door: {0:00}%", progress / unlockTime * 100);
        }
        GUI.TextArea(new Rect(100, 50, 200, 100), text);
    }
}
