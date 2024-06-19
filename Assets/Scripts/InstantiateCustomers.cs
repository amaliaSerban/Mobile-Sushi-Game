using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCustomers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spawnObj;
    private void Awake()
    {
        StartCoroutine(SpawnCustomers());

    }
    void Update()
    {
           
       
       
    }
    void SpawnCustomer()
    {
        Customer newCustomer = gameObject.GetComponent<CustomerRandomizer>().RandomCustomer();
        GameObject customer = Instantiate(newCustomer.customerPrefab, spawnObj.transform.position, spawnObj.transform.rotation);
        customer.transform.tag = "Customer";
        customer.GetComponent<NPCScript>().setTable(newCustomer.table);
    }
    IEnumerator SpawnCustomers()
    { 
        yield return new WaitForSeconds(1.5f);
        SpawnCustomer();

        yield return new WaitForSeconds(4f);
        SpawnCustomer();

        yield return new WaitForSeconds(7f);
        SpawnCustomer();

        yield return new WaitForSeconds(15f);
        SpawnCustomer();

        yield return new WaitForSeconds(15f);
        SpawnCustomer();

        yield return new WaitForSeconds(15f);
        SpawnCustomer();

        yield return new WaitForSeconds(15f);
        SpawnCustomer();


    }
}
