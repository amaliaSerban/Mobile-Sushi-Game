using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRandomizer : MonoBehaviour
{
    [SerializeField] Customer[] customers;
    [SerializeField] Table[] tables;
    // Start is called before the first frame update
    public Customer RandomCustomer()
    {
        int i = Random.Range(0, customers.Length);
        customers[i].table=RandomTable();
        return customers[i];
    }
    private Table RandomTable()
    {
        int i = Random.Range(0, tables.Length);
        if (tables[i].isEmpty)
        {
            return tables[i];
        }
        else
        {
            while (tables[i].isEmpty!=true) 
            {
                i = Random.Range(0, tables.Length);
            }
            return tables[i];
        }
    }
}
[System.Serializable]
public class Customer
{
    public GameObject customerPrefab;
    public Table table;
}
[System.Serializable]
public class Table
{
    public GameObject chair;
    public GameObject platePosition;
    public GameObject orderPlane;
    public bool isEmpty;

    
}