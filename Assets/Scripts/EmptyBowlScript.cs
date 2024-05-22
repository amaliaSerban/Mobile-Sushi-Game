using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBowlScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitUntilBowlDissappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartWait()
    {
        StartCoroutine(WaitUntilBowlDissappear());  
    }
    IEnumerator WaitUntilBowlDissappear()
    {
        yield return new WaitForSeconds(2f);
       Destroy(gameObject);
    }
}