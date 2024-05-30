using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCustomers : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void Awake()
    {
        
    }
    void Start()
    {
        Customer newCustomer=gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        Instantiate(newCustomer.customerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
