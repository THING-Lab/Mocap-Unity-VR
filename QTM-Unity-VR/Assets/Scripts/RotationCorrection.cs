using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrection : MonoBehaviour
{
    public GameObject QTMCamera;
    public GameObject accelCamera;

    public float lerpSpeed;

    // Update is called once per frame
    void Update() {
        Quaternion A = QTMCamera.transform.rotation * Quaternion.Inverse(accelCamera.transform.localRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, A, lerpSpeed);
        transform.position = QTMCamera.transform.position;
    }
}
