using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCustomers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spawnObj;
    private GameObject GameManager;
   
    private int customers;
    private void Awake()
    {
        GameManager = GameObject.Find("GameManager");
        setDay();
       StartInstantiating();
    }
    public void setDay()
    {
       
        customers= GameManager.GetComponent<Level>().customers;
    }
    void Update()
    {
           
       
       
    }
    public void StartInstantiating()
    {
        StartCoroutine(SpawnCustomers());

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

        yield return new WaitForSeconds(7f);
       SpawnCustomer();

       yield return new WaitForSeconds(10f);
       SpawnCustomer();

      for (int i = 0; i < customers - 3; i++)
      {
          yield return new WaitForSeconds(20f);
          SpawnCustomer();
      }
    }
}
