using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject character;
    public GameObject player;

    protected float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 predatorPos = character.transform.position;

        print(playerPos - predatorPos);

        float deltaX = (playerPos - predatorPos).x;
        float deltaZ = (playerPos - predatorPos).z;

        if (deltaX != 0)
        {
            predatorPos += (deltaX / Math.Abs(deltaX)) * Vector3.right * Time.deltaTime * speed;
        }

        if (deltaZ != 0)
        {
            predatorPos += (deltaZ / Math.Abs(deltaZ)) * Vector3.forward * Time.deltaTime * speed;
        }

        character.transform.position = predatorPos;
    }

    protected bool IsOnFloor()
    {
        return character.transform.position.y <= 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collide!");
    }
}
