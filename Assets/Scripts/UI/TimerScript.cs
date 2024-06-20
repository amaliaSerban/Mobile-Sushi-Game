using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Gradient gradient;
    public Image fill;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 1;
        setMaxTime(); 
        SetGradient(time);
    }
    void setMaxTime()
    {
        fill.fillAmount = time;
    }
    void SetGradient(float time)
    {
        fill.fillAmount = time;
        fill.color=gradient.Evaluate(time);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            time -= 0.2f;
            SetGradient(time);  
        }
    }
}
