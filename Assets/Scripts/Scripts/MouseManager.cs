using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMouseClickInteractable;
    public float rayDistance = 200;
    public LayerMask mask;

    public Texture2D arrow;
    public Texture2D target;

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance, mask))
        {
            switch (hit.collider.tag)
            {
                case "Rock":
                    Cursor.SetCursor(arrow, Vector3.zero, CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!hit.collider.CompareTag("Rock"))
                {
                    OnMouseClickInteractable.Invoke(hit.point);
                }  
            }
        }
        else
        {
            Cursor.SetCursor(arrow, Vector3.zero, CursorMode.Auto);
        }
    }
}

