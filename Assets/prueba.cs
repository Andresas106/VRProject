using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;

public class prueba : MonoBehaviour
{
   XRHandSubsystem handSubsystem;

    void Start()
    {
        handSubsystem = XRGeneralSettings.Instance?
            .Manager?
            .activeLoader?
            .GetLoadedSubsystem<XRHandSubsystem>();

        if (handSubsystem == null)
        {
            Debug.LogError("XRHandSubsystem no encontrado.");
        }
    }

    void Update()
    {
        if (handSubsystem == null)
            return;

        XRHand hand = handSubsystem.leftHand; // Cambia a rightHand si lo prefieres

        if (hand.isTracked)
        {
            bool isFist = IsFingerBent(hand, 1) && // Thumb
                          IsFingerBent(hand, 5) && // Index
                          IsFingerBent(hand, 9) && // Middle
                          IsFingerBent(hand, 13) && // Ring
                          IsFingerBent(hand, 17);   // Little

            if (isFist)
            {
                Debug.Log("¡Puño detectado!");
            }
        }
    }

    bool IsFingerBent(XRHand hand, int baseJointId)
    {
        var root = hand.GetJoint((XRHandJointID)baseJointId);       // ej: Index base
        var tip  = hand.GetJoint((XRHandJointID)(baseJointId + 3)); // ej: Index tip

        if (root.TryGetPose(out Pose rootPose) && tip.TryGetPose(out Pose tipPose))
        {
            float dist = Vector3.Distance(rootPose.position, tipPose.position);
            return dist < 0.04f; // Ajusta según pruebas
        }

        return false;
    }
}
