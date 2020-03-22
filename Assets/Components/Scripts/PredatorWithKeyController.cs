using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorWithKeyController : MonoBehaviour
{
    public GameObject key;
    public PredatorController predator;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (predator.GetHP() == 0)
        {
            if (key)
            {
                key.transform.position = predator.transform.position;
                key.SetActive(true);
            }
        }
    }
}
