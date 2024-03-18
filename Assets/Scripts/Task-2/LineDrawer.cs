using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer line; 
    private Vector3 mousePos; 
    public Material material; 
    private int currLines = 0;

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                CreateLine();
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(0, mousePos);
            line.SetPosition(1, mousePos);

        }
        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
            line = null;
            currLines++;
        }
        else if(Input.GetMouseButton(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
        } 
              
    }

    void CreateLine()
    {
        line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        line.material = material;
        line.positionCount = 2;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.useWorldSpace = true;
        line.numCapVertices = 90;
    }
                //public LineRenderer lineRenderer;
                //public LayerMask circleLayer;

                //private Camera mainCamera;
                //private bool isDrawing = false;

                //void Start()
                //{
                //    mainCamera = Camera.main;
                //    lineRenderer.positionCount = 0;
                //}

                //void Update()
                //{
                //    if (Input.GetMouseButtonDown(0))
                //    {
                //        isDrawing = true;
                //        lineRenderer.positionCount = 1;
                //        lineRenderer.SetPosition(0, GetWorldPosition());
                //    }
                //    else if (Input.GetMouseButtonUp(0))
                //    {
                //        isDrawing = false;
                //        CheckForCollisions();
                //        lineRenderer.positionCount = 0;
                //    }

                //    if (isDrawing)
                //    {
                //        lineRenderer.positionCount++;
                //        lineRenderer.SetPosition(lineRenderer.positionCount - 1, GetWorldPosition());
                //    }
                //}

                //Vector3 GetWorldPosition()
                //{
                //    return mainCamera.ScreenToWorldPoint(Input.mousePosition);
                //}

                //void CheckForCollisions()
                //{
                //    Vector3[] linePositions = new Vector3[lineRenderer.positionCount];
                //    lineRenderer.GetPositions(linePositions);

                //    foreach (Vector3 position in linePositions)
                //    {
                //        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, 0.1f, circleLayer);
                //        foreach (Collider2D collider in hitColliders)
                //        {
                //            Destroy(collider.gameObject);
                //        }
                //    }
                //}  
            }
