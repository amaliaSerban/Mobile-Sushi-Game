using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int customers = 7;
    // Start is called before the first frame update
    public void customerLeft()
    {
        customers--;
    }
    void Start()
    {
        StartCoroutine(CheckLevelEnd());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CheckLevelEnd()
    {
        yield return new WaitUntil(() => customers== 0);
        gameObject.GetComponent<WinScreen>().EndLevel();
    }
}
