using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxDistance = 100f;
    private BuildingHighlight lastBuilding;

    void Update()
    {
        RaycastHit hit;
        Vector3 endPosition = transform.position + transform.forward * maxDistance;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            endPosition = hit.point;
            
            BuildingHighlight building = hit.collider.GetComponent<BuildingHighlight>();
            
            if (building != null)
            {
                if (building != lastBuilding)
                {
                    if (lastBuilding != null) lastBuilding.RemoveHighlight();
                    building.AddHighlight();
                    lastBuilding = building;
                }
            }
            else
            {
                RemoveLastBuildingHighlight();
            }
        }
        else
        {
            RemoveLastBuildingHighlight();
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    void RemoveLastBuildingHighlight()
    {
        if (lastBuilding != null)
        {
            lastBuilding.RemoveHighlight();
            lastBuilding = null;
        }
    }
}
