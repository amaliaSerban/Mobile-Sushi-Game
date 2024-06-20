using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOrderImage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image image;
    public void ChangeImage(Sprite foodSprite)
    {
       image.GetComponent<Image>().sprite = foodSprite; 
    }
}
