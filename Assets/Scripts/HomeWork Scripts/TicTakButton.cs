using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTakButton : MonoBehaviour
{
    public static int num = 1;

    // Assign these via the Inspector in Unity
    [SerializeField] private Image regImage = null;  // prefab Image 
    [SerializeField] private Sprite xSprite = null;  // 'X' image
    [SerializeField] private Sprite oSprite = null;  //  'O' image
    [SerializeField] private TextMeshProUGUI textMeshPro = null;
    [SerializeField] private ParticleSystem particle = null;// let's have funn

    bool pressed = false;

    // Function to change the image based on whether num is even or odd
    public void ChangeImage()
    {
        if (!pressed)
        {
            if (num % 2 == 0)//for 'O'
            {
                Debug.Log("Even");
                regImage.sprite = oSprite;
                textMeshPro.text = "O";
                pressed = true;
                num++;
            }
            else// for 'X'
            {
                Debug.Log("UNEven");
                regImage.sprite = xSprite;
                textMeshPro.text = "X";
                pressed = true;
                num++;
            }
        }
    }
}
