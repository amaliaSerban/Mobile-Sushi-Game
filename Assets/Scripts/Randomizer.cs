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
        int i = Random.Range(0, 100);
        for (int j = 0; j < orders.Length; j++)
        {
            if (i > orders[j].minProbability && i <= orders[j].maxProbability)
            {
                return orders[j];
            }

        }
        return null;
    }
}
[System.Serializable]
public class order
{
    public enum foodType { Ramen, Udon, Sushi };
    public foodType type;
    public int minProbability=0,maxProbability=0;
}
