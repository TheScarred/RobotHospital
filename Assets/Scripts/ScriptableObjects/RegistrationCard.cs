using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class RegistrationCard : MonoBehaviour
{

    public static int cardIndex = 0;
    public float hp;
    Vector2 ScreenPos;
    public float dps = 0.4f;
    float timer = 0f;

    Image profile,head, chest, legs;
    Material heartFill;

    bool heartEmpty;
    // Start is called before the first frame update
    private void Awake()
    {
        Image[] selfContruct = GetComponentsInChildren<Image>();

        selfContruct = selfContruct.OrderBy(x => x.name).ToArray();

        profile = selfContruct[0];
        head = selfContruct[2];
        chest = selfContruct[3];
        legs = selfContruct[4];
        heartFill = selfContruct[1].material;

        hp = Random.Range(50f, 100f);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Hurt(dps);
            timer = 0;
        }
    }

    public void SetScreenPos()
    {

    }

    public void Hurt(float dps)
    {
        hp -= dps;
        heartFill.SetFloat("_amount", hp/100);
    }

    public void SetPieces(Sprite Head, Sprite Chest, Sprite Legs)
    {
        head.sprite = Head;
        profile.sprite = Head;
        chest.sprite = Chest;
        legs.sprite = Legs;
    }
}
