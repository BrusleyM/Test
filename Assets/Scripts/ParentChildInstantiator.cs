using UnityEngine;
using System.Collections.Generic;

public class ParentChildInstantiator : MonoBehaviour
{
    [Header("Prefab for Child Structure")]
    public GameObject parentPrefab; // Prefab to instantiate as a child

    [Header("GameObjects to Instantiate")]
    public List<GameObject> objectsToInstantiate = new List<GameObject>();

    private void OnValidate()
    {
        foreach (var go in objectsToInstantiate)
        {
            // Check if the prefab is already instantiated as a child
            if (!HasChildWithName(go.transform, $"{go.name} Grabbable"))
            {
                SetUpGrabbable(go);
            }
        }
    }

    private void SetUpGrabbable(GameObject go)
    {
        GameObject childGo = Instantiate(parentPrefab, go.transform);
        childGo.transform.localPosition = Vector3.zero;
        childGo.name = $"{go.name} Grabbable";
    }

    private bool HasChildWithName(Transform parent, string childName)
    {
        Transform? existingChild = null;
        foreach (Transform child in parent)
        {
            existingChild = parent.FindChildRecursive(childName);
        }

        return existingChild is not null;
    }

}