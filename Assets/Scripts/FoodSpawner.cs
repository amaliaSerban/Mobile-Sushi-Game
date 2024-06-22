using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject RamenPrefab;
    [SerializeField] GameObject UdonPrefab;
    [SerializeField] GameObject SushiPrefab;
    private AudioSource audioSource;

    public Slot[] slots;

  
    //[SerializeField] 
    void Start()
    {
        audioSource=GetComponent<AudioSource>();    
    }
    public void SpawnFood(Order food)
    {
        switch (food.type)
        { 
            case Order.foodType.Ramen:
                {
                    Slot newSlot = GetEmptySlot();
                    if(newSlot != null)
                    {
                        GameObject foodPrefab = Instantiate(RamenPrefab, newSlot.slotObj.transform.position, newSlot.slotObj.transform.rotation);
                        audioSource.Play();
                        foodPrefab.GetComponent<FoodInteraction>().slot = newSlot;
                        foodPrefab.name = "Ramen"; break;
                    }
                    else 
                    { 
                        break; 
                    } 
                }        
            case Order.foodType.Udon:
                {
                    Slot newSlot = GetEmptySlot();
                    if (newSlot != null)
                    {
                        GameObject foodPrefab = Instantiate(UdonPrefab, newSlot.slotObj.transform.position, newSlot.slotObj.transform.rotation);
                        audioSource.Play();
                        foodPrefab.GetComponent<FoodInteraction>().slot = newSlot;
                        foodPrefab.name = "Udon"; break;
                    }
                    else { break; }
                }
               
            case Order.foodType.Sushi:
                {
                    Slot newSlot = GetEmptySlot();
                    if (newSlot != null)
                    {
                        GameObject foodPrefab=Instantiate(SushiPrefab, newSlot.slotObj.transform.position, newSlot.slotObj.transform.rotation);
                        audioSource.Play();
                        foodPrefab.GetComponent<FoodInteraction>().slot = newSlot;
                        foodPrefab.name = "Sushi"; break;
                    }
                    else { break; }
                }
        }    
    }
    public Slot GetEmptySlot()
    {   
        if (slots[0].isEmpty == true)
        {
            slots[0].isEmpty = false;
            return slots[0];
        }
        if (slots[1].isEmpty == true)
        {
            slots[1].isEmpty = false;
            return slots[1]; 
        }
        if(slots[2].isEmpty == true)
        {
            slots[2].isEmpty = false;
            return slots[2];
        }
       
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //IEnumerator Queue()
    //{
    //    yield return new WaitUntil();
    //}
}
[System.Serializable]
public class Slot
{ 
    public GameObject slotObj;
    public bool isEmpty;
}


