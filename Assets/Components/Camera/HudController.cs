using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBar;
    public Slider staminaBar;
    public ChickenController player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.GetHP();
        staminaBar.value = player.GetStamina();
    }
}
