using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGProjecileGroup : MonoBehaviour
{
    public GameObject centerBullet;

    public int num0fTentacles = 3;
    public int num0fBulletsForOnTentacle = 3;
    public float distanceBetweenBullets = 0.5f;
    public bool enaleCenterBullet = true;

    public SGUtil.AXIS m_axisMove = SGUtil.AXIS.X_AND_Y;
    public float m_rotationSpeed = 90.0f;

    private Transform rootTransform;

    private void Awake()
    {
        rootTransform = new GameObject("Root").GetComponent<Transform>();
        rootTransform.SetParent(transform, false);

        if(num0fTentacles < 2)
        {
            return;
        }

        float addAngle = 360.0f / num0fTentacles;

        for(int i = 0; i < num0fTentacles; i++)
        {
            Quaternion quat = Quaternion.identity;
            switch(m_axisMove)
            {
                case SGUtil.AXIS.X_AND_Y:
                    quat = Quaternion.Euler(new Vector3(0.0f, 0.0f, addAngle * i));
                    break;
                case SGUtil.AXIS.X_AND_Z:
                    quat = Quaternion.Euler(new Vector3(0.0f, addAngle * i, 0.0f));
                    break;
                default:
                    break;
            }
            for(int k = 0;k < num0fBulletsForOnTentacle; k++)
            {
                var transBullet = ((GameObject)Instantiate(centerBullet, rootTransform)).GetComponent<Transform>();
                switch (m_axisMove)
                {
                    case SGUtil.AXIS.X_AND_Y:
                        transBullet.position += (quat * Vector3.up * ((k + 1) * distanceBetweenBullets));
                        break;
                    case SGUtil.AXIS.X_AND_Z:
                        transBullet.position += (quat * Vector3.forward * ((k + 1) * distanceBetweenBullets));
                        break;
                    default:
                        break;
                }
            }
        }
        centerBullet.SetActive(enaleCenterBullet);
    }
    public void UpdateRotate()
    {
        switch (m_axisMove)
        {
            case SGUtil.AXIS.X_AND_Y:
                rootTransform.eulerAngles = new Vector3(0.0f, 0.0f, m_rotationSpeed * SGTimer.Instance.deltaTime);
                break;
            case SGUtil.AXIS.X_AND_Z:
                rootTransform.eulerAngles = new Vector3(0.0f, 0.0f, m_rotationSpeed * SGTimer.Instance.deltaTime);
                break;

            default:
                break;
        }
    }
}
