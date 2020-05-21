//This script detects mouse clicks on a plane using Plane.Raycast.
//In your GameObject's Inspector, set your clickable distance and attach a cube GameObject in the appropriate fields

using UnityEngine;

public class PlaneRay : MonoBehaviour
{
    //Attach a cube GameObject in the Inspector before entering Play Mode
    public GameObject m_Cube;
    
    //Attach a plane Collider in the Inspector before entering Play Mode
    public Collider m_Coll;
    
    
    void Start()
    {

    }
    
    void Update()
    {
        
        //Detect when there is a mouse click
        if (Input.GetMouseButton(0))
        {
            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (m_Coll.Raycast(ray, out hit, 100.0f))
            {
                Vector3 hitPoint = ray.GetPoint(hit.distance);
                m_Cube.transform.position = hitPoint;
            }
            
        }
        
    }
}
