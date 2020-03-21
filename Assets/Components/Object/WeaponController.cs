using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
  public ChickenController player;
  public GameObject weapon;
  public float minDist = 1f;
  public float attack = 5f;
  public float range = 2f;
  public string text = "Press 'E' to pickup.";
  private float dist;
  private bool pickup = false;
  // private float h = Screen.height*1f/2;
  // private float w = Screen.width*1f/2;

  public float GetAttack() {
    return attack;
  }

  public float GetRange() {
    return range;
  }

  void Update()
  {
    if (pickup) {
      weapon.transform.position = player.transform.position;
    } else {
      dist = Vector3.Distance(player.transform.position, weapon.transform.position);
      if (dist <= minDist && Input.GetKey(KeyCode.E)) {
        player.OnPickUpWeapon(this);
        pickup = true;
      }
    }
  }

  // else if (pickup && Input.GetKey(KeyCode.Escape))
  // {
  //   pickup = false;
  // }

  void OnGUI()
  {
    if (dist <= minDist && !pickup)
    {
      GUI.TextArea(new Rect(100, 50, 200, 100), text);
    }
  }
}