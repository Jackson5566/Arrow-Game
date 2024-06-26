using UnityEngine;

[System.Serializable]
public struct DianaAnim
{
    public Sprite sprite;
    public RuntimeAnimatorController raConroller;
    public string name;
}

public class MainAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public DianaAnim[] dianaAnim;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        string lastGameName = DataStorage.GetGameName();

        foreach (DianaAnim dianaAnim in dianaAnim)
        {
            if (dianaAnim.name == lastGameName)
            {
                animator.runtimeAnimatorController = dianaAnim.raConroller;
                spriteRenderer.sprite = dianaAnim.sprite;
                break;
            }
        }
    }


}
