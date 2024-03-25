using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillMana : MonoBehaviour
{
    public HUD manaBar;
    public Image fillImage;

    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = manaBar.currentMana / manaBar.maxMana;    
        slider.value = fillValue;
    }
}
