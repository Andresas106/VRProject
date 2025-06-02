// Este script crea un bot�n en el inspector para aplicar un material permanentemente (en modo edici�n)
using UnityEngine;
using UnityEditor;

public class ApplyMaterialEditor : EditorWindow
{
    private GameObject targetRoot;
    private Material materialToApply;

    [MenuItem("Tools/Aplicar Material a Todos")]
    public static void ShowWindow()
    {
        GetWindow<ApplyMaterialEditor>("Aplicar Material");
    }

    private void OnGUI()
    {
        GUILayout.Label("Aplicar Material a Todos los MeshRenderers", EditorStyles.boldLabel);
        targetRoot = (GameObject)EditorGUILayout.ObjectField("Objeto Ra�z", targetRoot, typeof(GameObject), true);
        materialToApply = (Material)EditorGUILayout.ObjectField("Material", materialToApply, typeof(Material), false);

        if (GUILayout.Button("Aplicar Material"))
        {
            if (targetRoot == null || materialToApply == null)
            {
                Debug.LogWarning("Selecciona un objeto ra�z y un material.");
                return;
            }

            int count = 0;

            // MeshRenderer
            foreach (MeshRenderer mr in targetRoot.GetComponentsInChildren<MeshRenderer>(true))
            {
                Undo.RecordObject(mr, "Aplicar Material");
                mr.sharedMaterial = materialToApply;
                count++;
            }

            // SkinnedMeshRenderer
            foreach (SkinnedMeshRenderer smr in targetRoot.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                Undo.RecordObject(smr, "Aplicar Material");
                smr.sharedMaterial = materialToApply;
                count++;
            }

            Debug.Log($"Material aplicado a {count} objetos.");
        }
    }
}
