using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] GameObject table;
    public enum foodType { Ramen, Udon, Sushi };
    public foodType type;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && type.ToString()== other.name)
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
