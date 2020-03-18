using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
  public GameObject door;

  protected bool isOpened = false;

  public void Toggle() {
    isOpened = !isOpened;
    door.SetActive(!isOpened);
  }

  void Update() {
    if (Input.GetKey(KeyCode.E)) {
      Toggle();
    }
  }
}