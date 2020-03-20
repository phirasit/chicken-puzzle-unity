using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
  public GameObject door;
  public PredatorController predator;

  protected bool isOpened = false;

  public void Toggle() {
    isOpened = !isOpened;
    door.SetActive(!isOpened);

    if (predator) {
      predator.active = true;
    }
  }
}