using UnityEngine;
using GestureRecognizer;

public class GestureHandler : MonoBehaviour
{
    [SerializeField] private UILineRenderer uiLineRenderer;
    [SerializeField] private DrawDetector drawDetector;
    [SerializeField] private SpellBook spells;
    private CharacterInputController characterInputController;

    public void Start()
    {
        characterInputController ??= SingletoneData.Player.GetComponent<CharacterInputController>();
    }

    public void OnRecognize(RecognitionResult result)
    {
        uiLineRenderer.enabled = false;

        if (result != RecognitionResult.Empty)
        {
            Vector2 gistureMeanPointOnViewport = FindMeanPoint(uiLineRenderer.Points.ToArray());
            Vector2 worldPoint = Camera.main.ViewportToWorldPoint(gistureMeanPointOnViewport);
            if (result.gesture.id == @"\")
            {
                spells.Dash(characterInputController, worldPoint);
            }
        }
    }

    private Vector2 FindMeanPoint(Vector2[] points)
    {
        float tempX = 0;
        float tempY = 0;
        foreach (var point in points)
        {
            tempX += point.x;
            tempY += point.y;
        }
        return new Vector3(tempX / points.Length, tempY / points.Length);
    }
}