using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> selected = new List<GameObject>();
    public float speed = 10.0f;
    public Vector3 pos = new Vector3(2.80f,6.55f,-1.95f);
    public Vector3 offset = new Vector3(1,0,0);

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray;
                RaycastHit ratcas;
                ray = Camera.main.ScreenPointToRay(touch.position);
                LayerMask mask = LayerMask.GetMask("Destroyable");
                if (Physics.Raycast(ray, out ratcas, Mathf.Infinity, mask))
                {
                    GameObject hitObject = ratcas.transform.gameObject;

                    if (hitObject.CompareTag("Destroyable")&&!hitObject.GetComponent<Destroyable>().isSelected)
                    {
                        hitObject.GetComponent<Outline>().enabled = true;
                        hitObject.GetComponent<Destroyable>().isSelected = true;
                        selected.Add(hitObject);
                        if (selected.Count >= 2)
                        {
                            if (selected[0].GetComponent<Destroyable>().itemName == selected[1].GetComponent<Destroyable>().itemName)
                            {
                                selected[0].gameObject.transform.position = Vector3.Lerp(selected[0].transform.position, pos+offset, 1)*Time.deltaTime*speed;
                                selected[1].gameObject.transform.position = Vector3.Lerp(selected[1].transform.position, pos-offset, 1)*Time.deltaTime*speed;
                                
                                  foreach (var item in selected)
                                {
                                    item.GetComponent<Outline>().OutlineColor = Color.green;

                                    //coroutine = 
                                    StartCoroutine(itemsDestroy(item));

                                }
                                
                                Invoke("ClearSelected", 0.5f);

                            }
                            else
                            {
                                foreach (var item in selected)
                                {
                                    item.GetComponent<Outline>().OutlineColor = Color.red; 
                                }
                                Invoke("ClearSelected", 0.5f);
                            }
                        }
                        //Destroy(hitObject);
                    }

                }
                else
                {

                }
            }
        }
    }

    private void ClearSelected()
    {
        foreach (var item in selected)
        {
            item.GetComponent<Outline>().enabled = false;
            ColorUtility.TryParseHtmlString("#0BFF00",out Color defaultColor);
            item.GetComponent<Outline>().OutlineColor = defaultColor ;
            item.GetComponent<Destroyable>().isSelected=false;
        }
        selected.Clear();
    }

    private IEnumerator itemsDestroy(GameObject item)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);

            //item.SetActive(false);
        }
    }




}
