using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour

{
    [SerializeField] Order[] orders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Order OrderRandomizer()
    {
        int i = Random.Range(0, orders.Length);
        //for (int j = 0; j < orders.Length; j++)
        //{
        //    if (i > orders[j].minProbability && i <= orders[j].maxProbability)
        //    {
        //        return orders[j];
        //    }

        //}
        return orders[i];
    }
}
[System.Serializable]
public class Order
{
    public enum foodType { Ramen, Udon, Sushi };
    public foodType type;
    public Material foodImage;
    public int minProbability=0,maxProbability=0;
}

