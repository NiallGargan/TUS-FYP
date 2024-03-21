using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[RequireComponent(typeof(BezierCurve), typeof(PolygonCollider2D))]
public class LineCollision : MonoBehaviour
{
    Line line;
    MeshCollider mesh;

    void Start()
    {
        line = GameObject.Find("LineHandler").GetComponent<Line>();
        mesh = GameObject.Find("LineHandler").GetComponent<MeshCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if mesh collider colliders with wall, invoke the Line turn off script
        if(mesh)
        {
            Debug.Log("HIT");
            line.TurnOff();
        }
    }
}