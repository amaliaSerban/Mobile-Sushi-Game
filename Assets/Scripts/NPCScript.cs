using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class NPCScript : MonoBehaviour
{
    private Table table;
    //public enum foodType { Ramen, Udon, Sushi };
    // public foodType type;
    private Order order;
    private Animator animator;
   // [SerializeField] GameObject photoPlane;
    private GameObject randomizer;
    private GameObject spawnerObj;
    private NavMeshAgent agent;
    private GameObject exit;
    private bool ate = false;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();

        randomizer = GameObject.Find("FoodRandomizer");
        order = randomizer.GetComponent<Randomizer>().OrderRandomizer();

        spawnerObj = GameObject.Find("FoodSpawner");

        exit = GameObject.Find("spawnPoint");
        ate = false;
        
    }
    void Start()
    {
        // photoPlane.GetComponent<Renderer>().material = order.foodImage;
        //   StartCoroutine(WaitUntilCookedFood());
        agent.SetDestination(table.chair.transform.position);
        StartCoroutine(WaitUntilReachDestination());
    }
    public void setTable(Table randomTable)
    {
        table=randomTable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && order.type.ToString() == other.name)
        {
            other.GetComponent<FoodInteraction>().PlaceOnTable(table.platePosition.transform.position);
            table.orderPlane.SetActive(false);
            animator.SetBool("eating", true);
            StartCoroutine(WaitUntilFinishEating());

        }
    }
    IEnumerator WaitToOrder()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log(order.type.ToString());
        table.orderPlane.SetActive(true);
        table.orderPlane.GetComponent<Renderer>().material = order.foodImage;
        StartCoroutine(WaitUntilCookedFood());
    }
    IEnumerator WaitUntilFinishEating()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("eating", false);
        yield return new WaitForSeconds(1f);
        agent.SetDestination(exit.transform.position);
        animator.SetBool("walking", true);
        ate = true;
        StartCoroutine(WaitUntilReachDestination());

      
    }
     IEnumerator WaitUntilCookedFood()
     {
        //Debug.Log("before cook");
        yield return new WaitForSeconds(4f);
        spawnerObj.GetComponent < FoodSpawner>().SpawnFood(order);
       // Debug.Log("after cook");

     }
    IEnumerator WaitUntilReachDestination()
    {
        yield return new WaitForSeconds(0.025f);
        Debug.Log(agent.remainingDistance);
        yield return new WaitUntil(() => agent.remainingDistance <= 0);
        animator.SetBool("walking", false);
        if(ate==false)
             StartCoroutine(WaitToOrder());
        else Destroy(gameObject);
    }
  }



