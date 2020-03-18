using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NoteController : MonoBehaviour
{
  public ChickenController player;
  public GameObject note;
  public float minDist = 5f;
  public string text = "There's someting on high place\nPress 'Esc' to cancel.";
  private float dist;
  private bool reading = false;
  // private float h = Screen.height*1f/2;
  // private float w = Screen.width*1f/2;

  void Update()
  {
    dist = Vector3.Distance(player.transform.position, note.transform.position);
    if (dist <= minDist)
    {
      if (Input.GetKey(KeyCode.E))
      {
        reading = true;
      }
      if (reading && Input.GetKey(KeyCode.Escape))
      {
        reading = false;
      }
    }
    else
    {
      reading = false;
    }
  }

  void OnGUI()
  {
    if (dist <= minDist)
    {
      GUI.TextArea(new Rect(100, 50, 200, 100), "Press 'E' to read.");
      if (reading)
    {
      GUI.TextArea(new Rect(100, 50, 200, 100), text);
    }
    }
  }
}