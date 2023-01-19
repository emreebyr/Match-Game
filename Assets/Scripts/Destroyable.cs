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

            Debug.Log("saaaa");
             collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            /*gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
           
          
            transform.rotation = Quaternion.identity;

            foreach (var item in GetComponent<GameManager>().selected)
            {
                Debug.Log(item);
            }
            */

        }
    }
}

