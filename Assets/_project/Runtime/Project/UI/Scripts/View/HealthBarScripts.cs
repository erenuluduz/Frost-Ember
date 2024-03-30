using System.Collections;
using System.Collections.Generic;
using _project.Runtime.Core.Singleton;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScripts : SingletonBehaviour<HealthBarScripts>
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
