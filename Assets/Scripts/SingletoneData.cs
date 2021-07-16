using UnityEngine;

public class SingletoneData : MonoBehaviour
{
    public static GameObject Player { get; private set; }

    [SerializeField] private GameObject _player;

    private void Awake()
    {
        Application.targetFrameRate = 100;
        Player = _player;
    }
}