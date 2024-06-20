using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBowlScript : MonoBehaviour
{
    [SerializeField] GameObject coin;
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
       GameObject coinInstance = Instantiate(coin, new Vector3(this.transform.position.x, 2.8f, this.transform.position.z), coin.transform.rotation);
       Destroy(gameObject);
    }
}