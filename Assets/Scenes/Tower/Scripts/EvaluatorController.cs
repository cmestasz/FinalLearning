using System.Collections;

public class EvaluatorController : AnyCharacterController, IKeyInteractable
{
    public IEnumerator Interact()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        ChooseNameSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
