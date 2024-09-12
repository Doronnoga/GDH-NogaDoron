using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TikButton 
{
    public class TicTakButton : MonoBehaviour
    {
        public static int num = 1;//to switch between pictures

        // Assign these via the Inspector in Unity
        [SerializeField] private Image regImage = null;  // prefab Image 
        [SerializeField] private Sprite xSprite = null;  // 'X' image
        [SerializeField] private Sprite oSprite = null;  //  'O' image
        [SerializeField] private TextMeshProUGUI textMeshPro = null;
        [SerializeField] private GameObject particleObject = null;//particlessss
        public int thisButtonIs = 0;

        public bool pressed = false;
        public TicTakButton()
        {
        }
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
                    particleObject.SetActive(true);
                    thisButtonIs = 2;
                }
                else// for 'X'
                {
                Debug.Log("UNEven");
                regImage.sprite = xSprite;
                textMeshPro.text = "X";
                pressed = true;
                particleObject.SetActive(true);
                num++;
                thisButtonIs = 1;
                }
            }
        }
    }
}
