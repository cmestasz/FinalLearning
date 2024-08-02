using UnityEngine;

public class AnyCharacterController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] names;
    protected string characterName;

    public void ChooseNameSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        characterName = names[Random.Range(0, names.Length)];
    }
}
