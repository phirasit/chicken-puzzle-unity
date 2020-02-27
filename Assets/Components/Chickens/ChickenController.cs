using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject character;
    public GameObject camera_obj;

    protected float speed = 5; 
    protected Vector3 character_camera_translation;
    
    // Start is called before the first frame update
    void Start()
    {
        character_camera_translation = new Vector3(0, 4, -4);
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected void Move()
    {
        Vector3 position = character.transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) {
            position += Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            position += Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            position += Vector3.right * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.Space) && IsOnFloor()) {
            rb.AddForce(0, 500, 0);
        }

        character.transform.position = position;
        camera_obj.transform.position = position + character_camera_translation;
    }

    protected bool IsOnFloor() {
        return character.transform.position.y <= 1;
    }
}
