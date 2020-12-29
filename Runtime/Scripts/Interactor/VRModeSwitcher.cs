using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class VRModeSwitcher : MonoBehaviour
    {
        public Camera cameraVR;
        public Camera camera2D;

        bool isGui = true;

        public UnityEvent onVRMode;
        public UnityEvent on2DMode;

        // Start is called before the first frame update
        void Start()
        {

            if(camera2D!=null) camera2D.gameObject.SetActive(false);
            onVRMode.Invoke();
        }

        void SwitchToVR()
        {
            if (cameraVR != null) cameraVR.gameObject.SetActive(true);
            if (camera2D != null) camera2D.gameObject.SetActive(false);
            onVRMode.Invoke();
        }

        void SwitchTo2D()
        {
            if (cameraVR != null) cameraVR.gameObject.SetActive(false);
            if (camera2D != null) camera2D.gameObject.SetActive(true);
            on2DMode.Invoke();
        }

        void OnGUI()
        {
            if (!isGui) return;


            if (GUI.Button(new Rect(10, 10, 100, 30), "VR Mode"))
                SwitchToVR();

            if (GUI.Button(new Rect(10, 50, 100, 30), "2D Mode"))
                SwitchTo2D();

            GUIStyle style = new GUIStyle();
            style.fontSize = 10;
            GUI.Label(new Rect(10, 90, 100, 30), "Press TAB to hide", style);

        }
    }
}