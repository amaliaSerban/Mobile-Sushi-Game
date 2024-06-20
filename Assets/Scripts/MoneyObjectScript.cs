using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyObjectScript : MonoBehaviour
{
    private bool pressed = false;
    private float amplitude = 0.6f;
    private float speed=4f;
    private float initialY;
    void Start()
    {
        //StartCoroutine(WaitUntilBowlDissappear());
        pressed = false;
        initialY=this.transform.position.y;
    }
    private void BoppingEfect()
    {
        this.transform.position = new Vector3(this.transform.position.x,initialY + amplitude * Mathf.Sin(speed * Time.time), this.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        BoppingEfect();
        if (Input.GetMouseButtonDown(0))
        {
            if (!pressed) 
            {
                Pressed();
            }
            
        }
    }
    void Pressed()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.name==this.name)
            {
                pressed = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pressed == true)
        {
            Destroy(gameObject);
           // StartCoroutine(CollectCoin());
        }
        if(other.tag=="customer")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator CollectCoin()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);    

    }
}
