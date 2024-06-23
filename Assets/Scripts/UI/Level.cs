using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int day = 1;
    public int customers = 7;
    public int target;
    public float timerSpeed;

    private int currentCustomers;
    private int moneyToCollect;

    private AudioSource MainAudioSource;

    public UnityEvent NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        MainAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        PrepareLevel();
    }
    private void PrepareLevel()
    {
        gameObject.GetComponent<MoneyManager>().money = 0;
        customers = 4 + day * 3;
        currentCustomers = customers;
        moneyToCollect = customers;
        target = 50 + day * 25;
        if (day <= 5)
        {
            timerSpeed = 0.02f * day;
        }
        else timerSpeed = 0.1f;
        StartCoroutine(CheckLevelEnd());

    }
    public void customerLeft()
    {
        currentCustomers--;
    }
    public void moneyCollected()
    {
        moneyToCollect--;
    }
  
    IEnumerator CheckLevelEnd()
    {
        yield return new WaitUntil(() => currentCustomers== 0 && moneyToCollect==0);
        gameObject.GetComponent<WinScreen>().EndLevel();
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PrepareLevel();
        NextLevel.Invoke();
        Time.timeScale = 1f;
    }
    public void nextLevel()
    {
        day++;
        PrepareLevel();
        NextLevel.Invoke();
        Time.timeScale = 1f;
        MainAudioSource.Play();

    }
}
