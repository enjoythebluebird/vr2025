using UnityEngine;
using Meta.XR.MRUtilityKit;

public class LayerApplier : MonoBehaviour
{
    public void GetRoomObjectAndApplyLayer()
    {
        MRUKRoom mrukComponent = Object.FindFirstObjectByType<MRUKRoom>();
        GameObject mrukObject = mrukComponent.gameObject;

        ApplyLayer(mrukObject, "Wall");
    }

    private void ApplyLayer(GameObject obj, string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        obj.layer = layer;

        foreach (Transform child in obj.transform) ApplyLayer(child.gameObject, layerName);
    }
}
