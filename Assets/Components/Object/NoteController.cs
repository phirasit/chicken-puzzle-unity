using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public Image noteImage;
    // Start is called before the first frame update
    void Start()
    {
        noteImage.enabled = false;
    }

    // Update is called once per frame
    public void showNote()
    {
        noteImage.enabled = true;
    }
    public void hideNote()
    {
        noteImage.enabled = false;
    }
}
