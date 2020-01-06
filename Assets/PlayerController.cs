using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dawid {
public class PlayerController : MonoBehaviour
{
    public float movespeed = 7f;
    public float destinationBuffer = 0.1f;
    public LayerMask clickable;


    private Vector3 destination;

    private void Start() {
        destination = transform.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickable)) {
                destination = hitInfo.point;
                destination.y = transform.position.y;
            }
        }
    }

    private void FixedUpdate() {
        var deltaMove = destination - transform.position;
        var dist = deltaMove.magnitude;
        deltaMove = deltaMove.normalized * movespeed * Time.deltaTime;
        if (deltaMove.magnitude < dist) {
            transform.Translate(deltaMove);
        }
        else {
            transform.position = destination;
        }
    }
}
}