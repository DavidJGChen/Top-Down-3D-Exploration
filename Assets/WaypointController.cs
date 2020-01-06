using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public LayerMask clickable;
    private new Renderer renderer;
    private void Awake() {
        renderer = GetComponent<Renderer>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickable)) {
                transform.localPosition = new Vector3(hitInfo.point.x, transform.localPosition.y, hitInfo.point.z);
                renderer.enabled = true;
                Invoke("Fade", 0.2f);
            }
        }
    }

    private void Fade() {
        renderer.enabled = false;
    }
}
