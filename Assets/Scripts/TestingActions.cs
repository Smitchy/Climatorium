using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class TestingActions : MonoBehaviour
{
    private bool prev;
    private bool presence;
    private InputDevice headDevice;

    private void Awake()
    {

        headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        Debug.Log(headDevice.characteristics);

    }
    private void Update()
    {
        headDevice.TryGetFeatureValue(CommonUsages.userPresence, out presence); //always returns true. Does not work in this Unity version. More modern method
        Debug.Log(XRDevice.userPresence); //obselete. Works 100% of the time.
        

    }
}
