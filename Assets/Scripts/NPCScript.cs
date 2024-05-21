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
    [SerializeField] Order[] orders;
    private Order randomOrder;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        randomOrder = OrderRandomizer();
    }
    public Order OrderRandomizer()
    {
        int i = Random.Range(0, 100);
        for (int j = 0; j < orders.Length; j++)
        {
            if (i > orders[j].minProbability && i <= orders[j].maxProbability)
            {
                return orders[j];
            }

        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food" && randomOrder.type.ToString()== other.name)
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
[System.Serializable]
public class Order
{
    public enum foodType { Ramen, Udon, Sushi };
    public foodType type;
    public int minProbability = 0, maxProbability = 0;
}
