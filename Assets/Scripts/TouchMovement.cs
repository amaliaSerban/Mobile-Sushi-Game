using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class TouchMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask clickableLayer;
    public bool canMove=true;


    public GameObject leftHand;
    public GameObject rightHand;
    public int freeHands = 2;

    public Animator animator;
    private bool isWalking=false;

    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator =gameObject.transform.GetChild(0).GetComponent<Animator>();
       //animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canMove)
            {
               
                SetTargetPos();
               
               
                //FaceTarget();
                //canMove = false;
            }

        }
        //if (isWalking==true)
        //{
        //    DestinationReached();
        //}


    }
  
    void SetTargetPos()
    {
         RaycastHit hit;
         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
         {
            //Debug.Log("test");
            animator.SetBool("Walking", true);
            if (hit.transform.tag == "food")
            {
                Debug.Log("tap on food");
                hit.transform.GetComponent<FoodInteraction>().pressed = true;
                agent.destination = hit.transform.GetChild(0).transform.position;

            } 
            else agent.destination = hit.point;

           StartCoroutine(WaitUntilReachTarget());
            
        }
            
        
    }
    IEnumerator WaitUntilReachTarget()
    {
        yield return new WaitForSeconds(0.025f);
        Debug.Log(agent.remainingDistance);
        yield return new WaitUntil(() => agent.remainingDistance <= 0);
        animator.SetBool("Walking", false);
    }
}
