using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiddlePointOffset : MonoBehaviour
{
    public Transform middlePoint;
    private Vector3 offsetLeft;
    private Vector3 offsetRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //offsets for the left and right of middle point 
        offsetLeft = new Vector3((middlePoint.position.x + 5), middlePoint.position.y, middlePoint.position.z);
        offsetRight = new Vector3((middlePoint.position.x - 5), middlePoint.position.y, middlePoint.position.z);

        //if object is tagged mid left or mid right it sets its positions to these offset points
        if (gameObject.CompareTag("MidPointLeft"))
        {
            gameObject.transform.position = offsetLeft;
        }

        if(gameObject.CompareTag("MidPointRight"))
        {
            gameObject.transform.position = offsetRight;
        }
    }
}
