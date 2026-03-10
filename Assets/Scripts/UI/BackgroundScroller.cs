using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Material material;
    Vector2 offset;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

   
    void Update()
    {
        offset += moveSpeed;
        material.mainTextureOffset = offset;
    }
}
