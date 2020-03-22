using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakWallController : MonoBehaviour
{
    public ChickenController player;
    public ClosetController closet;
    public float WallHP;
    public float dist;

    private float MaxWallHP = 15;
    private float minDist = 1.0f;
    private string text = "Press G to destroy.";

    private void Start()
    {
        WallHP = MaxWallHP;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (dist <= minDist && Input.GetKeyDown(KeyCode.G))
        {
            WallHP -= player.GetAttack();
        }
        if (WallHP <= 0)
        {
            if (closet) closet.Toggle();
            gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            GUI.TextArea(new Rect(100, 50, 200, 100), text);
        }

    }
}
