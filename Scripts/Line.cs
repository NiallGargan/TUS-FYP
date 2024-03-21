using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When line is attached, will make line handler object have Line Renderer and Collider 
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Line : MonoBehaviour
{
    public GameObject start, middle, end;
    public Color color;
    public int numberOfPoints = 20;
    LineRenderer line;
    MeshCollider meshCollider;
    public KeyCode shootLine = KeyCode.F;
    public bool lineEnabled;
    public bool lineCollision;
    public KeyCode curveStraight;
    public KeyCode curveLeft;
    public KeyCode curveRight;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        line.useWorldSpace = true;
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
    }

    void Update()
    {
        //Get key to change the middle point to one of the other middle points to cruve in other direction
        if (Input.GetKey(curveLeft))
        {
            middle = GameObject.Find("MidPointBoxLeft");
            Debug.Log("Line was changed to Left");
        }
        if (Input.GetKey(curveRight))
        {
            middle = GameObject.Find("MidPointBoxRight");
            Debug.Log("Line was changed to Right");
        }
        if (Input.GetKey(curveStraight))
        {
            middle = GameObject.Find("MidPointBox");
            Debug.Log("Line was changed to Straight");
        }

        //if collision is set to true, generate mesh collider every frame
        if (lineCollision == true)
        {
            GenerateMeshCollder();
        }

        //on F key down disable and enable the line
        if (Input.GetKeyDown(shootLine) && lineEnabled == true)
        {
            lineEnabled = false;
            line.enabled = false;
        }
        else if (Input.GetKeyDown(shootLine) && lineEnabled == false)
        {
            lineEnabled = true;
            line.enabled = true;
        }

        if (line == null || start == null || middle == null || end == null)
        {
            return; // no points specified
        }

        // setting line render colour
        line.startColor = color;

        //if the number of points on line is greater than 0, the position count is equal to number of points
        if (numberOfPoints > 0)
        {
            line.positionCount = numberOfPoints;
        }

        //runs curve point function every frame
        curvePoints();
    }
    public void curvePoints()
    {
        // set points for Bezier curve
        Vector3 p0 = start.transform.position;
        Vector3 p1 = middle.transform.position;
        Vector3 p2 = end.transform.position;

        //float used to go along each point in bezier curve
        float t;
        Vector3 position;

        for (int i = 0; i < numberOfPoints; i++)
            {
                //iterates through numberOfPoints
                t = i / (numberOfPoints - 1.0f);
                //bezier interpolation formula to calculate each point
                position = (1.0f - t) * (1.0f - t) * p0
                + 2.0f * (1.0f - t) * t * p1 + t * t * p2;
                //sets poisition of each pooint 
                line.SetPosition(i, position);
            }
        }

    //GetPosition returns each point in line as a array
    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[line.positionCount];
        line.GetPositions(positions);
        return positions;
    }

    //returns the width of the start of line, would of been used for the point algorithm
    public float GetWidth()
    {
        return line.startWidth;
    }

    //Generating a mesh collider of the line renderer
    public void GenerateMeshCollder()
    {
        Mesh mesh = new Mesh();
        //bakes mesh to line dimensions, use world space true
        line.BakeMesh(mesh, true);

        meshCollider.sharedMesh = mesh;
    }

    //turns off line when collides with wall
    public void TurnOff()
    {
        line.enabled = false;
        lineEnabled = false;
    }
}