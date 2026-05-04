using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Color beamColor;
    public Color hitColor;
    public float beamWidth = 0.1f;
    public float beamRange = 100f;
    private LineRenderer beamRenderer;
    private RaycastHit hitInfo;
    private Renderer hitRenderer;

    void Start()
    {
        // Create a LineRenderer for the laser beam
        beamRenderer = gameObject.AddComponent<LineRenderer>();
        beamRenderer.startWidth = beamWidth;
        beamRenderer.endWidth = beamWidth;
        beamRenderer.material.color = beamColor;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Activate the laser beam
                beamRenderer.enabled = true;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                // Cast a ray from the touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hitInfo, beamRange))
                {
                    // Check if the hit object has a Renderer component
                    hitRenderer = hitInfo.collider.gameObject.GetComponent<Renderer>();

                    if (hitRenderer != null)
                    {
                        // Apply the hit color to the hit object
                        hitRenderer.material.color = hitColor;
                    }

                    // Draw the laser beam to the hit point
                    beamRenderer.SetPosition(0, transform.position);
                    beamRenderer.SetPosition(1, hitInfo.point);
                }
                else
                {
                    // Draw the laser beam to the maximum range
                    beamRenderer.SetPosition(0, transform.position);
                    beamRenderer.SetPosition(1, transform.position + transform.forward * beamRange);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                // Deactivate the laser beam
                beamRenderer.enabled = false;

                if (hitRenderer != null)
                {
                    // Reset the hit object's color to its default
                    hitRenderer.material.color = hitRenderer.material.GetColor("_Color");
                }
            }
        }
    }
}
