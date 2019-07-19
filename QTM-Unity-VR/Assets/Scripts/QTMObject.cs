using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTMRealTimeSDK;
using QualisysRealTime.Unity;

// This class is very similar to QTM's RT Object,
// but I might need to make changes so I'm keeping it for now
public class QTMObject : MonoBehaviour
{
    public string objectName;
    public Vector3 rotationOffset;
    public float updateWindow = 0f;
    private float updateTimer = 0f;

    private bool ShouldOffsetRotation {
        get { return !(rotationOffset.x == 0 && rotationOffset.y == 0 && rotationOffset.z == 0); }
    }

    private RTClient rtClient;
    // Start is called before the first frame update
    void Start() {
        rtClient = RTClient.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        if (updateTimer > 0) updateTimer -= Time.deltaTime;

        if (rtClient.GetStreamingStatus()) {
            SixDOFBody trackedObj = rtClient.GetBody(objectName);

            if (!float.IsNaN(trackedObj.Position.sqrMagnitude)) {
                transform.position = trackedObj.Position * 3;
                // Debug.Log(trackedObj.Rotation);
                // if (updateTimer <= 0) {
                    if (ShouldOffsetRotation) {
                        transform.rotation = trackedObj.Rotation * Quaternion.Euler(rotationOffset);
                    } else {
                        transform.rotation = trackedObj.Rotation;
                    }

                //     updateTimer = updateWindow;
                // }
            }
        }
    }
}
