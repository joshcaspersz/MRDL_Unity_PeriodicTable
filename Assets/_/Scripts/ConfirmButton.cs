using HoloToolkit.Unity;
using HoloToolkit.Unity.Buttons;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : Button
{
    private SpriteRenderer ButtonSprite;
    private Color spirteStartColor = new Color(0.5f,0.5f,0.5f);

    public override void OnStateChange(ButtonStateEnum newState)
    {
       if (ButtonSprite == null && GameObject.Find("ConfirmButton"))
        {
            GameObject ConfirmButton = GameObject.Find("ConfirmButton");
            ButtonSprite = ConfirmButton.GetComponent<SpriteRenderer>();

        }
       
        Debug.Log(ButtonSprite.color.ToString());

        if (ButtonSprite && spirteStartColor == null)
        {
            spirteStartColor = ButtonSprite.color;
        }

        switch (newState)
        {
            case ButtonStateEnum.ObservationTargeted:
            case ButtonStateEnum.Targeted:
                ButtonSprite.color = spirteStartColor * 1.5f;
                break;

            case ButtonStateEnum.Pressed:
                Debug.Log("Pressed button");
                ButtonSprite.color = spirteStartColor * 2f;
                CowStory.Instance.PressedConfirmButton();

        
                break;

            default:
                ButtonSprite.color = spirteStartColor;
                break;
        }

        base.OnStateChange(newState);
    }

}