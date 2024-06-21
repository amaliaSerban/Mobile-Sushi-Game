using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame upda
    // te
    private GameObject GameManager;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Text winText;
    [SerializeField] Text moneyText;
    public UnityEvent ShowWinScreen;

    private int day=1;
    void Start()
    {
        GameManager = GameObject.Find("GameManager");

    }
    public void EndLevel()
    {
        ShowWinScreen.Invoke();
        moneyText.text = GameManager.GetComponent<MoneyManager>().money + " /100";
        if (GameManager.GetComponent<MoneyManager>().money >= 100)
        {
            winText.text = "You Won!";
            winScreen.SetActive(true);
        }
        else
        {
            winText.text = "You Lost";
            loseScreen.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
