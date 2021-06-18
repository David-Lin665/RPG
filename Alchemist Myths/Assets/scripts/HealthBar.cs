using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text currentHealthText;
    public Text maxHealthText;
    public Slider slider;
    public void SetMaxHealth(int Health){
        slider.maxValue = Health;
        slider.value = Health;
        maxHealthText.text = Health.ToString();
        currentHealthText.text = Health.ToString();
    }
    public void SetHealth(int Health)
    {
        slider.value = Health;
        currentHealthText.text = Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
