using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCustomers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spawnObj;
    private void Awake()
    {
        
    }
    void Start()
    {
        Customer newCustomer=gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        GameObject customer= Instantiate(newCustomer.customerPrefab,spawnObj.transform.position,spawnObj.transform.rotation);
        customer.GetComponent<NPCScript>().setTable(newCustomer.table);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
