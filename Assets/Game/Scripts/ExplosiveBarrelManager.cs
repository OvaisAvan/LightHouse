using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ExplosiveBarrelManager : MonoBehaviour
{
    public static List<ExplosiveBarrel> allTheBarrels = new List<ExplosiveBarrel>();
    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        foreach(ExplosiveBarrel barrel in allTheBarrels) {
            
            Vector3 managerPos = transform.position;
            Vector3 barrelPos = barrel.transform.position;
            float halfHeight = (managerPos.y - barrelPos.y) * .5f;
            Vector3 offSet = Vector3.up * halfHeight;

            Handles.DrawBezier(
                managerPos,
                barrelPos,
                managerPos-offSet,
                barrelPos-offSet,
                Color.red,
                EditorGUIUtility.whiteTexture,
                1f
                );
        }
    }
    #endif
}
