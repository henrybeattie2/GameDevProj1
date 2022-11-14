using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBarHB : MonoBehaviour
{
    public RectTransform bossHealthBarTransform;
    public float currentHealth = 1;
    private bool inCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScaleHealthBar(float amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
           currentHealth = 0;
        bossHealthBarTransform.sizeDelta = new Vector2(currentHealth, bossHealthBarTransform.sizeDelta.y);
    }
}