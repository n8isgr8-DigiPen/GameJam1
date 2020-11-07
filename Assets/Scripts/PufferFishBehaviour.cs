using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PufferFishBehaviour : MonoBehaviour
{
    Camera cam;
    Rigidbody2D pufferfishRB;
    public float speed;
    Vector2 target;
    // Use this for initialization
    void Start()
    {
        
        cam = Camera.main;
        pufferfishRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.Find("Player").transform.position; will impliment when we have player;
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = Vector3.Cross(mousePos-transform.position,Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        pufferfishRB.velocity = -transform.right * speed;
    }
}
