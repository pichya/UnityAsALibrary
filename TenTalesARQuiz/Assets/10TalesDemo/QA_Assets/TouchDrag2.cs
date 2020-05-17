using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag2 : MonoBehaviour
{
    public string gameState;
    public LayerMask clickMask;
     
    private Touch touch;
    private float speedModifier;
    
    private Vector3 mOffset;
    private float mZcoord;
    
    void Start()
    {
        speedModifier = 0.01f;
        gameState = "aimWait";
    }

    void OnMouseDown()
    {
        //if (gameloop.gameState == "aimWait")
       // {
         //   gameloop.gameState = "aimBall";
        //}
       // Debug.Log(gameloop.gameState);
        /*if (gameloop.gameState == "aimBall")
        {
            mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }*/
    }
    
    void OnMouseUp()
    {
      if (gameState == "aimBall")
        {
            /*
            BallLogic.CalculatePhysics();
            BallLogic.ApplyPhysics();
            gameloop.SetGameState("shootBall");
             */
            gameState = "aimWait";
        }
        
    }
    
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousepoint = Input.mousePosition;
        mousepoint.z = mZcoord;
        return Camera.main.ScreenToWorldPoint(mousepoint);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameState == "aimBall" || gameState == "aimWait" ){
            // Touch Move
            if (Input.touchCount>0)
            {
                this.gameObject.SetActive(true);
                touch = Input.GetTouch(0);
                
                if (touch.phase==TouchPhase.Moved)
                {
                    transform.localPosition = new Vector3( transform.localPosition.x + touch.deltaPosition.x * speedModifier, transform.localPosition.y + touch.deltaPosition.y * speedModifier, 0f);
                }
            }
            
            if (Input.GetMouseButtonDown(0) && gameState == "aimWait")
            {
                gameState = "aimBall";
            }else{
                gameState = "aimWait";
            }
            
            if (gameState == "aimBall"){
                Vector3 clickPosition = -Vector3.one;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast (ray, out hit, 200, clickMask)){
                    clickPosition = hit.point;
                }
                
               // Debug.Log(clickPosition);
                if (clickPosition != -Vector3.one){
                    transform.position = clickPosition;
                }
            }
            //}*/
            
        }
        
    }
}
