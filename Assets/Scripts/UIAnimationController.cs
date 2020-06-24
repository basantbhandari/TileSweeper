using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{

    public GUIAnimFREE[] startingMenu;

    void Start()
    {
        foreach (GUIAnimFREE ui in startingMenu)
        {
            ui.PlayInAnims();
        }
    }



}
