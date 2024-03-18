using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LineDrawer : MonoBehaviour
{ 
    public LineRenderer lineRenderer;
    public LayerMask circleLayer;

    private Camera mainCamera;
    private bool isDrawing = false;

    void Start()
    {
        mainCamera = Camera.main;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, GetWorldPosition());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            CheckForCollisions();
            lineRenderer.positionCount = 0;
        }

        if (isDrawing)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, GetWorldPosition());
        }
    }

    Vector3 GetWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void CheckForCollisions()
    {
        Vector3[] linePositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(linePositions);

        foreach (Vector3 position in linePositions)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, 0.1f, circleLayer);
            foreach (Collider2D collider in hitColliders)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
