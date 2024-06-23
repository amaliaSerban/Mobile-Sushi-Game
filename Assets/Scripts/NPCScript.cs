using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.Events;

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

    private bool selected;
    private GameObject exit;
    private bool ate = false;
    private bool ordered = false;
    private bool timeWentOut = false;
    //  private bool pressed = false;

    GameObject GameManager;
    
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();


        randomizer = GameObject.Find("FoodRandomizer");
        order = randomizer.GetComponent<Randomizer>().OrderRandomizer();

        randomizer = GameObject.Find("CustomerRandomizer");

        spawnerObj = GameObject.Find("FoodSpawner");

        exit = GameObject.Find("spawnPoint");

        GameManager = GameObject.Find("GameManager");

        ate = false;
        ordered = false;
        selected=false;
        timeWentOut = false;
    }
    void Start()
    {
        // photoPlane.GetComponent<Renderer>().material = order.foodImage;
        //   StartCoroutine(WaitUntilCookedFood());

        agent.SetDestination(table.chair.transform.position);
        StartCoroutine(WaitUntilReachDestination());
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!selected)
            {
                SelectCustomer();
            }
            
        }
        
    }
    public void setTable(Table randomTable)
    {
        table = randomTable;
    }
    void SelectCustomer()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.name == gameObject.name)
            {
                selected = true;
            }

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && order.type.ToString() == other.name && ate==false && selected && ordered)
        {
            ate = true;
            other.GetComponent<FoodInteraction>().PlaceOnTable(table.platePosition.transform.position);
            other.GetComponent<FoodInteraction>().getTable(table);
            table.orderPlane.GetComponent<TimerScript>().CheckTimer(table);
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
        table.orderPlane.GetComponent<ChangeOrderImage>().ChangeImage(order.foodSprite);
        table.orderPlane.GetComponent<TimerScript>().setMaxTime();
        StartCoroutine(Timer());
        ordered = true;
        StartCoroutine(WaitUntilCookedFood());
    }
    IEnumerator WaitUntilFinishEating()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("eating", false);
        yield return new WaitForSeconds(1f);
        agent.SetDestination(exit.transform.position);
        randomizer.GetComponent<CustomerRandomizer>().emptyTable(table);
        animator.SetBool("walking", true);
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
        if (ate == false && timeWentOut == false)
            StartCoroutine(WaitToOrder());
        else
        {
            GameManager.GetComponent<Level>().customerLeft();
            Destroy(gameObject);
        }
    }
    public void TimerWentOut()
    {
        timeWentOut = true;
        ate = true;
        table.orderPlane.SetActive(false);
        agent.SetDestination(exit.transform.position);
        randomizer.GetComponent<CustomerRandomizer>().emptyTable(table);
        animator.SetBool("walking", true);
        StartCoroutine(WaitUntilReachDestination());
    }
    IEnumerator Timer()
    {
        yield return new WaitUntil(() => table.orderPlane.GetComponent<TimerScript>().time <= 0);
        TimerWentOut();
    }
}



