using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (transform.position, target.transform.position);
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray,out hit))
            {
                
                    if (hit.collider.CompareTag("plus"))
                    {
                        if (distance>2)
                        {
                            transform.position += (transform.forward) * Time.deltaTime*5;
                        }
                        
                        
                    }else if (hit.collider.gameObject.CompareTag("minus"))
                    {
                        if (distance<7)
                        {
                            transform.position -= (transform.forward) * Time.deltaTime*5;
                        }
                        
                    }else if (hit.collider.gameObject.CompareTag("leftRot"))
                    {
                        transform.RotateAround(target.transform.position, new Vector3(0.0f,1.0f,0.0f),20*Time.deltaTime*5);
                        
                    }else if (hit.collider.gameObject.CompareTag("rightRot"))
                    {
                        transform.RotateAround(target.transform.position, new Vector3(0.0f,-1.0f,0.0f),20*Time.deltaTime*5);
                    }
                    
                
            }
        }
    }
}
