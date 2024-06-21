using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBowlScript : MonoBehaviour
{
    private GameObject coin;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject coinStarPrefab;
    private Table Table;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitUntilBowlDissappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    public void getTable(Table newTable)
    {
        Table=newTable;
    }
    private void SetPrefab()
    {
        if(Table.timer<0)
        {
            coin = null;
        }
        else
        {
            if(Table.timer<0.25f)
            {
                coin = coinPrefab;
                coin.GetComponent<MoneyObjectScript>().starCoin = false;
            }
            else
            {
                coin = coinStarPrefab;
                coin.GetComponent<MoneyObjectScript>().starCoin = true;
            }
        }
        
    }
    public void StartWait()
    {
        StartCoroutine(WaitUntilBowlDissappear());  
    }
    IEnumerator WaitUntilBowlDissappear()
    {
       yield return new WaitForSeconds(2f);
       SetPrefab();
        if (coin != null)
        {
           Instantiate(coin, new Vector3(this.transform.position.x, 2.8f, this.transform.position.z), coin.transform.rotation);
        }
     
       //coinInstance.transform.tag = coin.transform.tag;
       Destroy(gameObject);
    }
}