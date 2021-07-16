using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public void Dash(CharacterInputController characterController, Vector2 worldPoint)
    {
        StartCoroutine(characterController.StunFor(0.5f));

        Vector2 characterPosition = SingletoneData.Player.GetComponent<Transform>().position;

        SingletoneData.Player.GetComponent<Rigidbody2D>().AddForce(
            (worldPoint - characterPosition).normalized * 1000f,
            ForceMode2D.Impulse);
    }
}