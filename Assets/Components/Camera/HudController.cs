using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBar;
    public Slider staminaBar;
    public Slider predatorHealthBar;
    public ChickenController player;
    public PredatorController predator;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.GetHP();
        staminaBar.value = player.GetStamina();
        predatorHealthBar.value = predator.GetHP();
    }
}
