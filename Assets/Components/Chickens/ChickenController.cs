using System;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject character;
    public GameObject camera_obj;
    public PredatorController predator;

    public float hp;
    public float stamina;
    public float atkDist;

    protected float MaxHP = 100;
    protected float MaxStamina = 100;
    protected float StaminaRecoveryRate = 10;
    protected float Speed = 5; 
    protected float JumpPower = 0.7f;
    protected float JumpStaminaCost = 3;
    protected float minAtkDist = 2f;

    // Start is called before the first frame update
    void Start()
    {
        hp = MaxHP;
        stamina = MaxStamina;
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Recovery();
        CheckIfAttack();
    }

    public void OnAttack(float damage) {
        hp = Mathf.Max(0, hp-damage);
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetStamina()
    {
        return stamina;
    }

    protected void Move()
    {
        Vector3 position = character.transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) {
            position += Vector3.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            position += Vector3.back * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            position += Vector3.left * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            position += Vector3.right * Speed * Time.deltaTime;
        }
        
        character.transform.position = position;

        if (Input.GetKey(KeyCode.Space)) {
            Jump();
        }
    }

    protected void Jump()
    {
        RaycastHit hit;
        float distance = 1;
        Vector3 dir = Vector3.down;

	    if(Physics.Raycast(transform.position, dir, out hit, distance) && stamina >= JumpStaminaCost) {
            stamina -= JumpStaminaCost;
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    protected void Recovery()
    {
        stamina = Mathf.Min(MaxStamina, stamina + StaminaRecoveryRate * Time.deltaTime);
    }

    private void CheckIfAttack()
    {
        //TODO: Check if weapon has already picked up or not
        bool hasWeapon = true;
        if (hasWeapon)
        {
            atkDist = Vector3.Distance(character.transform.position, predator.transform.position);
            //TODO: Add weapon damage
            float weaponDmg = 15;
            if (Input.GetKeyDown(KeyCode.R) && atkDist < minAtkDist)
            {
                predator.OnAttack(weaponDmg);
            }
        }
        
    }

}
