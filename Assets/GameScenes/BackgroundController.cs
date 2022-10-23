using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    public bool isSwitched = false;
    public Image firstBackground;
    public Image secondBackground;
    public Animator animator;
//dans cette partie on utilise les animations de changement de background placé dans l'animator
    public void SwitchBackground(Sprite sprite)
    {
        if (!isSwitched)
        {
            secondBackground.sprite = sprite;
            animator.SetTrigger("switchFirst");
        }
        else
        {
            firstBackground.sprite = sprite;
            animator.SetTrigger("switchSecond");
        }
        isSwitched = !isSwitched;
    }

    public void SetBackground(Sprite sprite)
    {
        if (!isSwitched)
        {
            firstBackground.sprite = sprite;
        }
        else
        {
            secondBackground.sprite = sprite;
        }
    }
}


