using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamareEffect : MonoBehaviour
{
    [Range(0.0f,1.0f)]
    public float ligthIntensity=1.0f;
    [SerializeField]
    Material material;

    /*9public float Ligth
    {
        set
        {
            ligthIntensity = value;
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        //material = new Material(Shader.Find("Hidden / PostprosesingEffect"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_intensity", ligthIntensity);
        Graphics.Blit(source, destination, material);
    }
}
