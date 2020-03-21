using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NoteController : MonoBehaviour
{
  public ChickenController player;
  public GameObject note;
  public float minDist = 1f;
  public string text;

  public string text1 = "Press 'E' to read.";
  public string text2 = ".\n\nPress 'Esc' to cancel.";
  private float dist;
  private bool reading = false;
  // private float h = Screen.height*1f/2;
  // private float w = Screen.width*1f/2;

  void Start()
  {
    text = text1;
  }
  void Update()
  {
    dist = Vector3.Distance(player.transform.position, note.transform.position);
    if (dist <= minDist)
    {
      if (Input.GetKey(KeyCode.E))
      {
        reading = true;
        text = text2;
      }
      else if (reading && Input.GetKey(KeyCode.Escape))
      {
        reading = false;
        text = text1;
      }
    }
    else
    {
      reading = false;
      text = text1;
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