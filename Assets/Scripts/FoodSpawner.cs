using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject RamenPrefab;
    [SerializeField] GameObject UdonPrefab;
    [SerializeField] GameObject SushiPrefab;
    [SerializeField] 
    void Start()
    {
        
    }
    public void SpawnFood(Order food)
    {
        switch (food.type)
        { 
            case Order.foodType.Ramen:
                Instantiate(RamenPrefab); break;
            case Order.foodType.Udon:
                Instantiate(UdonPrefab); break;
            case Order.foodType.Sushi:
                Instantiate(SushiPrefab); break;

        }    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
