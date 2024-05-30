using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class NPCScript : MonoBehaviour
{
    [SerializeField] GameObject table;
    //public enum foodType { Ramen, Udon, Sushi };
    // public foodType type;
    private Order order;
    private Animator animator;
    [SerializeField] GameObject photoPlane;
    private GameObject randomizer;
    private GameObject spawnerObj;


    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        randomizer = GameObject.Find("RandomizerObj");
        order = randomizer.GetComponent<Randomizer>().OrderRandomizer();
        spawnerObj = GameObject.Find("FoodSpawner");
    }
    void Start()
    {
       // photoPlane.GetComponent<Renderer>().material = order.foodImage;
       //   StartCoroutine(WaitUntilCookedFood());
       StartCoroutine(WaitToOrder());
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && order.type.ToString() == other.name)
        {
            other.GetComponent<FoodInteraction>().PlaceOnTable(table.transform.position);
            photoPlane.SetActive(false);
            animator.SetBool("eating", true);
            StartCoroutine(WaitUntilFinishEating());

        }
    }
    IEnumerator WaitToOrder()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log(order.type.ToString());
        photoPlane.SetActive(true);
        photoPlane.GetComponent<Renderer>().material = order.foodImage;
        StartCoroutine(WaitUntilCookedFood());
    }
    IEnumerator WaitUntilFinishEating()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("eating", false);
      
    }
     IEnumerator WaitUntilCookedFood()
     {
        //Debug.Log("before cook");
        yield return new WaitForSeconds(4f);
        spawnerObj.GetComponent < FoodSpawner>().SpawnFood(order);
       // Debug.Log("after cook");

     }
}


