using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpriteShadow : MonoBehaviour
{
    public Vector2 offset = new Vector2(-3f, -3f);

    private SpriteRenderer sprRndrCaster;
    private SpriteRenderer sprRndrShadow;

    private Transform transCaster;
    private Transform transShadow;

    public Material shadowMat;
    public Color shadowColor;
    // Start is called before the first frame update
    void Start()
    {
        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "Shadow";
        transShadow.localRotation = Quaternion.identity;
        transShadow.localScale = new Vector3(1f,1f,1f);

        sprRndrCaster = GetComponent<SpriteRenderer>();
        sprRndrShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();


        sprRndrShadow.material = shadowMat;
        sprRndrShadow.color = shadowColor;
        sprRndrShadow.sortingLayerName = sprRndrCaster.sortingLayerName;
        sprRndrShadow.sortingOrder = sprRndrCaster.sortingOrder - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transShadow.position = new Vector2(transCaster.position.x + offset.x, transCaster.position.y + offset.y);
        sprRndrShadow.sprite = sprRndrCaster.sprite;
        sprRndrShadow.color = shadowColor;
    }
}
