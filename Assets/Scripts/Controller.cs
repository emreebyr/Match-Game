using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject [] itemsCreater;
    public int width,height,depth;
    public bool starter=false;
    public GameObject UI;


    
    
    void Start()
    {

    }

    private void SpawnManager()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                    {
                        creater(x, y, z);
                    }
            }
        }
    }

    public void creater(int x, int y, int z)
    {
        if(starter)
        {
            GameObject newRandomObj = Random_items();
            GameObject new_item = GameObject.Instantiate (newRandomObj,new Vector3(x,y,Random.Range(-y-5,y+5)),Quaternion.identity);
            new_item.GetComponent<Destroyable>().itemName = newRandomObj.name;
        }

    }
    
    public GameObject Random_items()
    {
        int rand = Random.Range (0,itemsCreater.Length);
        return itemsCreater[rand];
    }


    void Update()
    {
        
    }

    public void StartButton()
    {   
        Destroy(UI);
        starter=true;
        Invoke("SpawnManager",1f);

    }

    public void quitButton()
    {   
        Application.Quit();

    }



}
