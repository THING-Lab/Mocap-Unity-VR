using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrection : MonoBehaviour
{
    public Transform rotationSource;
    public QTMObject outputTarget;

    // Update is called once per frame
    void Update() {
        outputTarget.rotationOffset = Quaternion.Inverse(rotationSource.localRotation).eulerAngles;
    }
}
