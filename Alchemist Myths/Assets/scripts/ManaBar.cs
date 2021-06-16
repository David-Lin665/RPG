using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Text currentManaText;
    public Text maxManaText;
    // Start is called before the first frame update
    public Slider slider;
    public void SetMaxMana(int Mana){
        slider.maxValue = Mana;
        slider.value = Mana;
        maxManaText.text = Mana.ToString();
        currentManaText.text = Mana.ToString();
    }
    public void SetMana(int Mana)
    {
        slider.value = Mana;
        currentManaText.text = Mana.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
