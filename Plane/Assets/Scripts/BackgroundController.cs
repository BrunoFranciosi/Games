using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //getting my material
    private Renderer myBack;
    //getting my x Offset
    private float xOffset = 0f;
    //position of my texture
    private Vector2 textureOffset;
    [SerializeField]private float velocity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //taking my background
        myBack = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xOffset += Time.deltaTime * velocity;
        //passing the xOffset to the x axis of my texture
        textureOffset.x = xOffset;
        //moving the offset x of my renderer
        myBack.material.mainTextureOffset = textureOffset;
    }
}
