using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
   public int money=0;
    [SerializeField] Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CollectCoin()
    {
        money += 7;
        Debug.Log("money: "+money);
        UpdateUI();

    }
    public void CollectStarCoin()
    {
        money += 15;
        Debug.Log("money: " + money);
        UpdateUI();
       
    }
    private void UpdateUI()
    {
        moneyText.GetComponent<Text>().text = money + " / " +gameObject.GetComponent<Level>().target;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
