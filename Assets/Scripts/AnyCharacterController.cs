using System.Collections;
using UnityEngine;

public class AnyCharacterController : MonoBehaviour
{
    [SerializeField] private string[] names;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float interval;
    protected string characterName;
    private int spriteIndex;

    public void ChooseNameSprite()
    {
        characterName = names[Random.Range(0, names.Length)];
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (true)
        {
            sr.sprite = sprites[spriteIndex];
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            yield return new WaitForSeconds(interval);
        }
    }
}
