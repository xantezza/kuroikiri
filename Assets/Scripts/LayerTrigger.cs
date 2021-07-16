using UnityEngine;

public class LayerTrigger : MonoBehaviour
{
    public string layer;
    public string sortingLayer;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            ChangeLayer(SingletoneData.Player);
        }
        ChangeLayer(other.gameObject);
    }

    private void ChangeLayer(GameObject other)
    {
        other.gameObject.layer = LayerMask.NameToLayer(layer);

        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }
    }
}