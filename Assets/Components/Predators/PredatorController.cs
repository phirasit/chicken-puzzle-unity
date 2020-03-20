using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject character;
    public ChickenController player;
    public bool active;

    protected float speed = 3;
    protected float attack = 5;
    public float hp;

    protected float MaxHP = 150;
    private bool isCollide;

    // Start is called before the first frame update
    void Start()
    {
        hp = MaxHP;
        isCollide = false;
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !isCollide) {
            Follow();
        }
        if (hp == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Follow()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 predatorPos = character.transform.position;

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

    public void OnAttack(float damage)
    {
        hp = Mathf.Max(0, hp - damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollide = true;
            player.OnAttack(attack);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollide = false;
    }

    public float GetHP()
    {
        return hp;
    }
}
