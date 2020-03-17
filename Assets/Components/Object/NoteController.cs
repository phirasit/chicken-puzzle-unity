using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteController : MonoBehaviour
{
  public ChickenController player = new ChickenController();
  public float minDist = 5f;
  public string text = "There's someting on high place";
  private float dist;
  private bool reading = false;

  void Update()
  {
    dist = Vector3.Distance(player.character.transform.position, gameObject.transform.position);
    if (dist <= minDist)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        if (reading)
        {
          reading = false;
        }
        else
        {
          reading = true;
        }
      }
    }
    else
    {
      reading = false;
    }
  }

  void OnGUI()
  {
    if (reading)
    {
      GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), text);
    }
    else if (dist <= minDist)
    {
      GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), "Press 'E' to read.");
    }
  }
}