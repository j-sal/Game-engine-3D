using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    // Use this for initialization
    private GameObject gameObject;
    float x1;
    float x2;
    float x3;
    float x4;
    void Start()
    {
        gameObject = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(new Vector3(0, 1, 0 * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(new Vector3(0, -1, 0 * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(new Vector3(-1, 0, 0 * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(new Vector3(1, 0, 0 * Time.deltaTime));
        }
    }
}

