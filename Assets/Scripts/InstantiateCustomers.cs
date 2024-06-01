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
        StartCoroutine(SpawnCustomers());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCustomers()
    { 
        yield return new WaitForSeconds(1.5f);
        Customer newCustomer = gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        GameObject customer = Instantiate(newCustomer.customerPrefab, spawnObj.transform.position, spawnObj.transform.rotation);
        customer.GetComponent<NPCScript>().setTable(newCustomer.table);

        yield return new WaitForSeconds(4f);
        newCustomer = gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        customer = Instantiate(newCustomer.customerPrefab, spawnObj.transform.position, spawnObj.transform.rotation);
        customer.GetComponent<NPCScript>().setTable(newCustomer.table);

        yield return new WaitForSeconds(5f);
         newCustomer = gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        customer = Instantiate(newCustomer.customerPrefab, spawnObj.transform.position, spawnObj.transform.rotation);
        customer.GetComponent<NPCScript>().setTable(newCustomer.table);

    }
}
