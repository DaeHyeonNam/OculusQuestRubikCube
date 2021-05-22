using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBigCube : MonoBehaviour
{
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
    // Start is called before the first frame update
	public GameObject target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    void Swipe(){
    	if (Input.GetMouseButtonDown(1)){
    		firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    		//print(firstPressPos);
    	}
    	if(Input.GetMouseButtonUp(1)){
    		secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    		
    		currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
    		currentSwipe.Normalize();


    		if(LeftSwipe(currentSwipe)){
    			target.transform.Rotate(0, 90, 0 , Space.World);
    		}
    		else if(RightSwipe(currentSwipe)){
    			target.transform.Rotate(0, -90, 0, Space.World);
    		}
    	}

    }

    bool LeftSwipe(Vector2 swipe){
    	return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe){
    	return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
}
