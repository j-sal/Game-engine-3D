using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour {

    
    private GameObject gameObject;
    private float m_deltX = 0f;
    private float m_deltY = 0f;
    
    private float m_distance = 10f;
    private float m_mSpeed = 5f;
    
    private Vector3 m_mouseMovePos = Vector3.zero;

    void Start()
    {
        gameObject = GameObject.Find("police-car");
        this.gameObject.transform.localPosition = new Vector3(0, m_distance, 0);
    }

    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            m_deltX += Input.GetAxis("Mouse X") * m_mSpeed;
            m_deltY -= Input.GetAxis("Mouse Y") * m_mSpeed;
            m_deltX = ClampAngle(m_deltX, -360, 360);
            m_deltY = ClampAngle(m_deltY, -70, 70);
            transform.rotation = Quaternion.Euler(m_deltY, m_deltX, 0);
         }

        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            
            m_distance = Input.GetAxis("Mouse ScrollWheel") * 10f;
            
            this.gameObject.transform.localPosition = this.gameObject.transform.position + this.gameObject.transform.forward * m_distance;
        }
        
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                m_mouseMovePos = hitInfo.point;
            }
        }
        else if (Input.GetMouseButton(2))
        {
            Vector3 p = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                p = hitInfo.point - m_mouseMovePos;
                p.y = 10f;
            }
            this.gameObject.transform.localPosition = this.gameObject.transform.position - p * 10.05f; //在原有的位置上，加上偏移的位置量;
        }

        
        if (Input.GetKey(KeyCode.Space))
        {
            m_distance = 10.0f;
            this.gameObject.transform.localPosition = new Vector3(0, m_distance, 0);
        }
    }

    
    float ClampAngle(float angle, float minAngle, float maxAgnle)
    {
        if (angle <= -360)
            angle += 360;
        if (angle >= 360)
            angle -= 360;

        return Mathf.Clamp(angle, minAngle, maxAgnle);
    }
}
