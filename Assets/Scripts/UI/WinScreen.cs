using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static Unity.VisualScripting.Member;
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

    private AudioSource winAudioSource;
    private AudioSource MainAudioSource;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;

    private int day=1;
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        winAudioSource = gameObject.GetComponent<AudioSource>();
        MainAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();


    }
    public void EndLevel()
    {
        Time.timeScale = 0f;
        MainAudioSource.Stop();
        ShowWinScreen.Invoke();
        moneyText.text = GameManager.GetComponent<MoneyManager>().money + " /100";
        if (GameManager.GetComponent<MoneyManager>().money >= 100)
        {
            winAudioSource.clip = win;
            winAudioSource.Play();
            winText.text = "You Won!";
            winScreen.SetActive(true);
        }
        else
        {
            winAudioSource.clip = lose;
            winAudioSource.Play();
            winText.text = "You Lost!";
            loseScreen.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
