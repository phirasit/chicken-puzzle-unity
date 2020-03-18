using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
  public ChickenController player;
  public GameObject weapon;
  public float minDist = 1f;
  public string text = "This is stick.";
  private float dist;
  private bool pickup = false;
  // private float h = Screen.height*1f/2;
  // private float w = Screen.width*1f/2;

  void Update()
  {
    dist = Vector3.Distance(player.transform.position, weapon.transform.position);
    if (dist <= minDist)
    {
      if (Input.GetKey(KeyCode.E))
      {
        pickup = true;
        //pick weapon
      }
      if (pickup && Input.GetKey(KeyCode.Escape))
      {
        pickup = false;
        //drop weapon
      }
    }
  }

  void OnGUI()
  {
    if (dist <= minDist)
    {
      GUI.TextArea(new Rect(100, 50, 200, 100), "Press 'E' to pickup.");
      if (pickup)
      {
        GUI.TextArea(new Rect(100, 50, 200, 100), text);
      }
    }
  }
}