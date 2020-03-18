using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NoteController : MonoBehaviour
{
  public ChickenController player;
  public GameObject note;
  public float minDist = 5f;
  public string text = "There's someting on high place";
  private float dist;
  private bool reading = false;

  void Update()
  {
    dist = Vector3.Distance(player.transform.position, note.transform.position);
    if (dist <= minDist)
    {
      if (Input.GetKeyUp(KeyCode.E))
      {
        reading = true;
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
      GUI.TextArea(new Rect(100, 100, 500, 500), "Press 'E' to read.");
      if (reading)
      {
        GUI.TextArea(new Rect(100, 100, 500, 500), text);
      }
    }
  }
}