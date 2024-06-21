using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int money=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CollectCoin()
    {
        money += 7;
        Debug.Log("money: "+money);
    }
    public void CollectStarCoin()
    {
        money += 15;
        Debug.Log("money: " + money);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
