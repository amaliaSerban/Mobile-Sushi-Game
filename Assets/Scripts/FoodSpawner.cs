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

    [SerializeField] Slot[] slots;

  
    //[SerializeField] 
    void Start()
    {
        
    }
    public void SpawnFood(Order food)
    {
        switch (food.type)
        { 
            case Order.foodType.Ramen:
                {
                    GameObject newSlot = GetEmptySlot();
                    if(newSlot != null)
                    {
                        GameObject foodPrefab = Instantiate(RamenPrefab, newSlot.transform.position, newSlot.transform.rotation); 
                        foodPrefab.name = "Ramen"; break;
                    }
                    else { break; } 
                }        
            case Order.foodType.Udon:
                {
                    GameObject newSlot = GetEmptySlot();
                    if (newSlot != null)
                    {
                        GameObject foodPrefab = Instantiate(UdonPrefab, newSlot.transform.position, newSlot.transform.rotation); 
                        foodPrefab.name = "Udon"; break;
                    }
                    else { break; }
                }
               
            case Order.foodType.Sushi:
                {
                    GameObject newSlot = GetEmptySlot();
                    if (newSlot != null)
                    {
                        GameObject foodPrefab=Instantiate(SushiPrefab, newSlot.transform.position, newSlot.transform.rotation);
                        foodPrefab.name = "Sushi"; break;
                    }
                    else { break; }
                }
        }    
    }
    public GameObject GetEmptySlot()
    {   
        if (slots[0].isEmpty == true)
        {
            slots[0].isEmpty = false;
            return slots[0].slotObj;
        }
        if (slots[1].isEmpty == true)
        {
            slots[1].isEmpty = false;
            return slots[1].slotObj; 
        }
        if(slots[2].isEmpty == true)
        {
            slots[2].isEmpty = false;
            return slots[2].slotObj;
        }
       
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
[System.Serializable]
public class Slot
{ 
    public GameObject slotObj;
    public bool isEmpty;
}


