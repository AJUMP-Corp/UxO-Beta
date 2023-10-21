using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera seguir�
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento da c�mera
    public Vector3 offset; // Dist�ncia entre o jogador e a c�mera

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
