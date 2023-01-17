using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool isSelected;
    public string itemName;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (isSelected && collisionInfo.gameObject.GetComponent<Destroyable>().itemName == itemName)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
          
            transform.rotation = Quaternion.identity;
           // item.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

            foreach (var item in GetComponent<GameManager>().selected)
            {
                Debug.Log(item);
            }

        }
    }
}

