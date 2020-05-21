using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    //public Material releaseMaterial;
    //public Material touchMaterial;
    
    public Behaviour halo;
    
    public Collider m_Coll;
    
    Vector3 initialPosition;
    Vector3 currentPosition;
    string touchState;
        
    // Start is called before the first frame update
    void Start()
    {
        touchState = "TouchWait";
        halo.enabled = false;
        initialPosition = new Vector3( transform.position.x, transform.position.y, transform.position.z );
    }

    void OnTouchOn()
    {
        if (touchState == "TouchWait"){
            //
            //GetComponent<MeshRenderer>().material = touchMaterial;
            halo.enabled = true;
            //Detect when there is a mouse click
            if (Input.GetMouseButton(0))
            {
                //Create a ray from the Mouse click position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (m_Coll.Raycast(ray, out hit, 100.0f))
                {
                    Vector3 hitPoint = ray.GetPoint(hit.distance);
                    this.transform.position = hitPoint;
                }
            }
            
        }
    }
    
    void OnTouchOff()
    {
        if (touchState == "TouchWait"){
            //
            //GetComponent<MeshRenderer>().material = releaseMaterial;
            halo.enabled = false;
            currentPosition = new Vector3( transform.position.x, transform.position.y, transform.position.z );
            touchState = "TouchMove";
        }
    }
    
    void OnMouseDrag()
    {
        OnTouchOn();
    }
    
    void OnMouseUp()
    {
        OnTouchOff();
    }
    
    // Update is called once per frame
    void Update()
    {
        switch(touchState){
            case "TouchMove":
            transform.position = Vector3.Lerp(transform.position, initialPosition, 0.1f);
            if (Mathf.Abs(transform.position.x - initialPosition.x)<0.001 && Mathf.Abs(transform.position.y - initialPosition.y)<0.001 ){
                transform.position = new Vector3( initialPosition.x, initialPosition.y, initialPosition.z );
                touchState = "TouchWait";
            }
            break;
            
        }
    }
}
