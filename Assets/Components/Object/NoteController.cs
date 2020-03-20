using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NoteController : MonoBehaviour
{
  public ChickenController player;
  public GameObject note;
  public float minDist = 2f;
  public string text = "Press 'E' to read.";

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
        text = "There's someting on high place\n\nPress 'Esc' to cancel.";
      }
      else if (reading && Input.GetKey(KeyCode.Escape))
      {
        reading = false;
        text = "Press 'E' to read.";
      }
    }
    else
    {
      reading = false;
      text = "Press 'E' to read.";
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