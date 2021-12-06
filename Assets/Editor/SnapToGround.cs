using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnapToGround : MonoBehaviour
{
    [MenuItem("CustomTools/Snap To Ground %g")]
    public static void Ground()
    {
        foreach(Transform transform in Selection.transforms)
        {
            RaycastHit hitInfo;
            var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
            foreach(var hit in hits)
            {
                if(hit.collider.gameObject!= transform.gameObject)
                {
                     transform.position = hit.point;
                    break;
                }
            }
        }
    }

}
