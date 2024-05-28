using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiddlePoint : MonoBehaviour
{
    [Header("Mid Point Box")]
    public GameObject start;
    public GameObject end;
    public Transform targetTransform;
    public float height;
    public KeyCode heightUp;
    public KeyCode heightDown;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetTransform);

        //if the start or end point has changed, run UpdateMidTransform
        if (start.transform.hasChanged || end.transform.hasChanged)
        {
            UpdateMidTransform();
        }
        //raises or lowers midpoint
        if (Input.GetKey(heightUp))
        {
            height = height + 0.1f;
        }

        if (Input.GetKey(heightDown))
        {
            height = height - 0.1f;
        }

        // Calculate the distance between ObjectA and ObjectB
        float distance = Vector3.Distance(start.transform.position, end.transform.position) /2f;

        // Adjust the Y position based on the distance
        float newYPosition = distance * height;

        Vector3 newPosition = transform.position;
        newPosition.y = newYPosition;
        transform.position = newPosition;

    }

    void UpdateMidTransform()
    {
        //finds middle point by addding both start and end position of line and dividing it by 2
        Vector3 middlepoint = (start.transform.position + end.transform.position) / 2f;
        transform.position = middlepoint;

    }
}
