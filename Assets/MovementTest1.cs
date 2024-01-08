using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest1 : MonoBehaviour
{
    [SerializeField] private float m_speed;

    [SerializeField] private GameObject m_MainObject;
    [SerializeField] private Transform m_IndependentPivotPoint;
    [SerializeField] private Transform m_IndependentPivotPointOffset;
    [SerializeField] private GameObject m_IndependentObject;

    private void Start()
    {
        Vector3 independentDirection = (m_IndependentPivotPointOffset.transform.position - m_IndependentPivotPoint.transform.position).normalized;
        m_IndependentObject.transform.rotation = Quaternion.LookRotation(independentDirection, m_IndependentObject.transform.up);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            YRotation(1.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            YRotation(-1.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            XRotation(-1.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            XRotation(1.0f);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ZRotation(1.0f);
        }

        if (Input.GetKey(KeyCode.F))
        {
            ZRotation(-1.0f);
        }

        if (Input.GetKey(KeyCode.Y))
        {
            IndependentObjectRotation(1.0f);
        }

        if (Input.GetKey(KeyCode.H))
        {
            IndependentObjectRotation(-1.0f);
        }

        if (Input.GetKey(KeyCode.U))
        {
            MainObjectSpin(1.0f);
        }

        if (Input.GetKey(KeyCode.J))
        {
            MainObjectSpin(-1.0f);
        }

        m_IndependentObject.transform.position = m_IndependentPivotPoint.position;
        Vector3 rotationAxis = (m_IndependentPivotPointOffset.transform.position - m_IndependentPivotPoint.transform.position).normalized;
        m_IndependentObject.transform.LookAt(rotationAxis, m_IndependentObject.transform.up);

    }

    private void XRotation(float direction)
    {
        float mainSpeed = m_speed * Time.deltaTime * direction;
        Vector3 rotation = new Vector3(mainSpeed, 0, 0);
        m_MainObject.transform.Rotate(rotation, Space.World);

        Vector3 rotationAxis = (m_IndependentPivotPointOffset.transform.position - m_IndependentPivotPoint.transform.position).normalized;
        m_IndependentObject.transform.LookAt(rotationAxis, m_IndependentObject.transform.up);
    }

    private void YRotation(float direction)
    {
        float mainSpeed = m_speed * Time.deltaTime * direction;
        Vector3 rotation = new Vector3(0, mainSpeed, 0);
        m_MainObject.transform.Rotate(rotation, Space.World);

        Vector3 rotationAxis = (m_IndependentPivotPointOffset.transform.position - m_IndependentPivotPoint.transform.position).normalized;
        m_IndependentObject.transform.LookAt(rotationAxis, m_IndependentObject.transform.up);

    }

    private void ZRotation(float direction)
    {
        //Speed of the main part of the object
        float mainSpeed = m_speed * Time.deltaTime * direction;
        Vector3 rotation = new Vector3(0, 0, mainSpeed);
        m_MainObject.transform.Rotate(rotation, Space.World);

        //Rotation of the independent part of the object
        Vector3 rotationAxis = (m_IndependentPivotPointOffset.transform.position - m_IndependentPivotPoint.transform.position).normalized;
        m_IndependentObject.transform.LookAt(rotationAxis, m_IndependentObject.transform.up);
    }

    private void MainObjectSpin(float direction)
    {
        float speedChange = m_speed * Time.deltaTime * direction;
        Vector3 rotation = new Vector3(0, speedChange, 0);
        m_MainObject.transform.Rotate(rotation, Space.Self);
    }

    private void IndependentObjectRotation(float direction)
    {
        float speedChange = m_speed * Time.deltaTime * direction;
        Vector3 rotation = new Vector3(0, 0, speedChange);
        m_IndependentObject.transform.Rotate(rotation, Space.Self);

    }
}
