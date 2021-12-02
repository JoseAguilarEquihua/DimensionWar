using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillLifeBar : MonoBehaviour
{
    public DereckMovement playerHealth;
    public Image fillImage;
    private Slider slider;
    public Canvas canvas;
    public Canvas canvas2;


    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.Health;
        if (fillValue <= 1)
        {
            fillImage.color = Color.white;
        }
        else if (fillValue > 1)
        {
            fillImage.color = Color.red;
        } 
        if(fillValue < 1 )
        {
            canvas.enabled = false;
            canvas2.enabled = false;
        }
        if (DevianScript.enemies <= 0)
        {
            canvas.enabled = false;
            canvas2.enabled = false;
        }
        slider.value = fillValue;
        
        
    }
}
