using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DayText;
    [SerializeField] Text MoneyText;
    private GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    public void UpdateDay()
    {
        DayText.text = "Day " + GameManager.GetComponent<Level>().day;
    }
    public void UpdateMoney()
    {
        MoneyText.text = "0/ " + GameManager.GetComponent<Level>().target;
    }
}
