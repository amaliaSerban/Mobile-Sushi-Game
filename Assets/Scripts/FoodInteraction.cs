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
    public Slot slot;
    public GameObject player;
    public GameObject EmptyBowl;
    private GameObject bowlInstance;

    private GameObject FoodSpawner;
    
    void Start()
    {
        player = GameObject.Find("Player");
        FoodSpawner = GameObject.Find("FoodSpawner");
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
                pressed = false;
                Debug.Log("hands= " + other.GetComponent<TouchMovement>().freeHands);
                for(int i=0;i<=FoodSpawner.GetComponent<FoodSpawner>().slots.Length;i++)
                {
                    if (FoodSpawner.GetComponent<FoodSpawner>().slots[i].slotObj==slot.slotObj)
                    {
                        FoodSpawner.GetComponent<FoodSpawner>().slots[i].isEmpty = true;
                    }
                }
               
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
