using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform camera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.Find("ViewportCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.position);
        transform.Rotate(0f, 180f, 0f, Space.Self);
    }
}
