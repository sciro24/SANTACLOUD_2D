using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlloer : MonoBehaviour
{
    [SerializeField] private Transform Personaggio;

    [SerializeField] private bool seguiAsseX = false;

    [SerializeField] private float maxY;
    [SerializeField] private float minY;



    private void Update()
    {
        float posX;
        float posY;

        if (seguiAsseX)
        {
            posX = Personaggio.position.x;
            posY = Personaggio.position.y;
        }
        else
        {
            posX = transform.position.x;
            posY = Mathf.Clamp(Personaggio.position.y, minY, maxY);
        }

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
