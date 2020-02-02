using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FurnaceProfile : MonoBehaviour
{
    [SerializeField]
    Slider selfBar;
    [SerializeField]
    Image selfBarColor;
    [SerializeField]
    Image selfImage;
    float progress; //PROGRESS OF TGHE BAR

    [SerializeField]
    Sprite[] imageCollection;

    [SerializeField]
    Object[] craftResult;

    int currentImage;
    bool isCrafting;

    public bool Craft
    {
        get { return isCrafting; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isCrafting = false;
        currentImage = 0;
        selfImage.sprite=imageCollection[currentImage];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
            ChangeImage();
        if (Input.GetKeyDown(KeyCode.N))
            StartCraft();
    }
    public void StartCraft()
    {
        if(!isCrafting)
            StartCoroutine(StartCharge());
    }
    private IEnumerator StartCharge()
    {
        isCrafting = true;
        progress = 0.0f;
        while (progress <= 1.0f)
        {
            progress += Time.deltaTime / 5;
            selfBar.value = progress;
            selfBarColor.color = Color.Lerp(Color.red, Color.green, progress);
            yield return null;
        }


        GameObject.Instantiate(craftResult[currentImage],this.transform.GetChild(0).position,Quaternion.identity);
        selfBar.value = 0.0f;
        selfBarColor.color = Color.red;
        isCrafting = false;
    }

    public void ChangeImage()
    {
        if (isCrafting)
            return;

        currentImage++;
        if (currentImage >= imageCollection.Length)
            currentImage = 0;

        selfImage.sprite = imageCollection[currentImage];
    }
}
