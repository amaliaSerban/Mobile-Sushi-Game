using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodInteraction : MonoBehaviour
{

    // Start is called before the first frame update
    //public enum foodType { Ramen, Udon, Sushi };
    //public foodType type;
    public bool pressed = false;
    public GameObject player;
    public GameObject EmptyBowl;
    private GameObject bowlInstance;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("trigger enter");

        if(other.tag=="Player" && pressed==true)
        {
            if (other.GetComponent<TouchMovement>().freeHands > 0)
            {
                if (other.GetComponent<TouchMovement>().freeHands == 2)
                {
                    gameObject.transform.position = other.GetComponent<TouchMovement > ().leftHand.transform.position;
                }
                else
                {
                    gameObject.transform.position = other.GetComponent<TouchMovement>().rightHand.transform.position;
                }
                gameObject.transform.parent = other.transform;
                other.GetComponent<TouchMovement>().freeHands--;
                Debug.Log("hands= " + other.GetComponent<TouchMovement>().freeHands);
                pressed = false;
            }
        }
    }
    public void PlaceOnTable(Vector3 poz)
    {
        gameObject.transform.position = poz;
        gameObject.transform.parent = null;
        player.GetComponent<TouchMovement>().freeHands++;
        Debug.Log("hands= " + player.GetComponent<TouchMovement>().freeHands);
        StartCoroutine(WaitUntilEmptyBowl());
    }
    IEnumerator WaitUntilEmptyBowl()
    {
        yield return new WaitForSeconds(4f);
        bowlInstance= Instantiate(EmptyBowl,gameObject.transform.position,gameObject.transform.rotation);
        bowlInstance.GetComponent<EmptyBowlScript>().StartWait();
        Destroy(gameObject);
        

    }
   
}
