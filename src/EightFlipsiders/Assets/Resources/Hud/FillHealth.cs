using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public HUD healthBar;
    public Image fillImage;

    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = healthBar.currentHealth / healthBar.maxHealth;    
        slider.value = fillValue;
    }
}
