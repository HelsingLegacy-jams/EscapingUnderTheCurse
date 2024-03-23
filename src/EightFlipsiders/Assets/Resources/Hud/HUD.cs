using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public int maxMana = 5;

    public int currentMana;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        
    }

    
}
