using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    private int _degreesRotation = 40;
    private void Update()
    {
        transform.Rotate(0, _degreesRotation * Time.deltaTime, 0);
    }
}
