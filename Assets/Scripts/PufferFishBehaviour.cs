using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PufferFishBehaviour : MonoBehaviour
{
    Camera cam;
    Rigidbody2D pufferfishRB;
    public float speed;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = Vector3.Cross(mousePos-transform.position,Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        pufferfishRB.velocity = transform.right * speed;
    }
}
