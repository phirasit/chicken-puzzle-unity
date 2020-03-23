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
    protected float JumpPower = 0.5f;
    protected float JumpStaminaCost = 3;
    protected float minAtkDist = 2f;
    protected float attack = 1.0f;
    protected float attackRange = 2.0f;

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
    }

    public void OnPickUpWeapon(WeaponController weapon) {
        attack += weapon.GetAttack();
        attackRange = Mathf.Max(attackRange, weapon.GetRange());
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

    public float GetAttack()
    {
        return attack;
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

        if (Input.GetKeyDown(KeyCode.G)) {
            Attack();
        }
    }

    protected void Jump()
    {
        RaycastHit hit;
        float distance = 1;
        Vector3 dir = Vector3.down;

	    if (Physics.Raycast(transform.position, dir, out hit, distance) && stamina >= JumpStaminaCost) {
            stamina -= JumpStaminaCost;
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    protected void Attack()
    {
        PredatorController[] enemy = GameObject.FindObjectsOfType<PredatorController>();
        for (int i = 0; i < enemy.Length; ++i)
        {
            float distance = Vector3.Distance(transform.position, enemy[i].transform.position);
            if (distance <= attackRange) {
                enemy[i].OnAttack(attack);
            }
        }
    }

    protected void Recovery()
    {
        stamina = Mathf.Min(MaxStamina, stamina + StaminaRecoveryRate * Time.deltaTime);
    }
}
