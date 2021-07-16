using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float lerpSpeed;
    private Transform target;

    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        target = SingletoneData.Player.transform;
        offset = transform.position - target.position;
    }

    private void Update()
    {
        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}