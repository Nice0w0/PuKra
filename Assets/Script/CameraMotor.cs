using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 detla = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                detla.x = deltaX - boundX;
            }

            else
            {
                detla.x = deltaX - boundX;
            }

        }





        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundX)
        {
            if (transform.position.y < lookAt.position.y)
            {
                detla.y = deltaY - boundY;
            }
            else
            {
                detla.y = deltaY - boundY;
            }
        }

        transform.position += new Vector3(detla.x, detla.y, 0);
    }
}

