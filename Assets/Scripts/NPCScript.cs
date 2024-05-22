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

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        randomizer = GameObject.Find("RandomizerObj");
        order = randomizer.GetComponent<Randomizer>().OrderRandomizer();
    }
    void Start()
    {
        Debug.Log(order.type.ToString());
        photoPlane.GetComponent<Renderer>().material = order.foodImage;
    }
   

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && order.type.ToString()== other.name)
        {
            other.GetComponent<FoodInteraction>().PlaceOnTable(table.transform.position);
            animator.SetBool("eating", true);
            StartCoroutine(WaitUntilFinishEating());
           
        }
    }
    IEnumerator WaitUntilFinishEating()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("eating", false);

    }
}


