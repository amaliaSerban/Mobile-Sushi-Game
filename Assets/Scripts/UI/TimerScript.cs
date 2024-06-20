using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Gradient gradient;
    public Image fill;
    [SerializeField] float time=1f;
    // Start is called before the first frame update
    void Start()
    {
        //setMaxTime(); 
      
    }
    public void setMaxTime()
    {
        time = 1f;
        fill.fillAmount = time;
        BeginTimer();
    }
    void SetGradient(float time)
    {
        fill.fillAmount = time;
        fill.color=gradient.Evaluate(time);
    }
    private void BeginTimer()
    {
        SetGradient(time);
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while(time>=0)
        { 
            yield return new WaitForSeconds(1f);
            time -= 0.02f;
            SetGradient(time);
           
        }
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space)) 
    //    {
    //        time -= 0.2f;
    //        SetGradient(time);  
    //    }
    //}
}
