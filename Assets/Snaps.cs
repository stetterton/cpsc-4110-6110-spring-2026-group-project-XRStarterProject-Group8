using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GhostGridSnap : MonoBehaviour
{
    public GameObject realVisual;
    public GameObject ghostVisual;

    public float cellSize = 1f;
    public float gridY = 0f;

    private XRGrabInteractable grab;
    private bool isHeld = false;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        if (ghostVisual != null)
            ghostVisual.SetActive(false);

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        if (grab != null)
        {
            grab.selectEntered.RemoveListener(OnGrab);
            grab.selectExited.RemoveListener(OnRelease);
        }
    }

    private void SetRenderers(GameObject obj, bool state)
    {
        if (obj == null) return;

        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer r in renderers)
        {
            r.enabled = state;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;

        SetRenderers(realVisual, false);

        if (ghostVisual != null)
        {
            ghostVisual.SetActive(true);
            ghostVisual.transform.position = transform.position;
            ghostVisual.transform.rotation = transform.rotation;
        }
    }

    private void LateUpdate()
    {
        if (!isHeld || ghostVisual == null) return;

        Vector3 pos = transform.position;

        float snappedX = Mathf.Round(pos.x / cellSize) * cellSize;
        float snappedZ = Mathf.Round(pos.z / cellSize) * cellSize;

        ghostVisual.transform.position = new Vector3(snappedX, gridY, snappedZ);

        ghostVisual.transform.rotation = transform.rotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;

        if (ghostVisual != null)
        {
            transform.position = ghostVisual.transform.position;
            transform.rotation = ghostVisual.transform.rotation;
            ghostVisual.SetActive(false);
        }

        SetRenderers(realVisual, true);
    }
}