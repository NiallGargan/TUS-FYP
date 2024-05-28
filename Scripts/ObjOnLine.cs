using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnLine : MonoBehaviour
{
    public LineRenderer line;
    public GameObject objectToMove;
    public float speed;

    private Vector3[] positions = new Vector3[20];
    private Vector3[] pos;
    private int index = 0;

    void Awake()
    {
        line = GameObject.Find("LineHandler").GetComponent<LineRenderer>();
        pos = GetLinePointsInWorldSpace();
        objectToMove.transform.position = pos[index];
    }

    Vector3[] GetLinePointsInWorldSpace()
    {
        //Get the positions which are shown in the inspector 
        line.GetPositions(positions);

        //the list of array points returned are in world space
        return positions;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //move object towards the current position in the index
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position,
                                                pos[index],
                                                speed * Time.deltaTime);
        //object looks at each next point in the index to show the curve on the object
        transform.LookAt(pos[index]);

        //if the object has reached the current index position, index goes up by one to the next position
        if (objectToMove.transform.position == pos[index])
        {
            index += 1;
        }

        if (index == pos.Length)
        {
            Debug.Log("Fireball hit finished positions");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            Debug.Log("Fireball hit target");
            Destroy(gameObject);
        }
    }
}
