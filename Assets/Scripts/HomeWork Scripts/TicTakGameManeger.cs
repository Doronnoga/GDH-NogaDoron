using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TikButton;
using System.Linq;
using TMPro;


namespace manager 
{
    public class TicTakGameManeger : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup = null;
        [SerializeField] private TicTakButton b1;
        [SerializeField] private TicTakButton b2;
        [SerializeField] private TicTakButton b3;
        [SerializeField] private TicTakButton b4;
        [SerializeField] private TicTakButton b5;
        [SerializeField] private TicTakButton b6;
        [SerializeField] private TicTakButton b7;
        [SerializeField] private TicTakButton b8;
        [SerializeField] private TicTakButton b9;
        TicTakButton[] buttonArray;
        bool win = false;

        //for win screen
        [SerializeField] private GameObject winObject= null;
        [SerializeField] private TextMeshProUGUI winText = null;

        public bool AreValuesEqual(int valueToCheck, params int[] values)
        {
            // Check if all values are equal to valueToCheck
            return values.All(v => v == valueToCheck);
        }


        void Start()
        {
            // Initialize
            buttonArray = new TicTakButton[9] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            canvasGroup.interactable = true;// make it clickable
            // making sure it happen-- all initialize
            for (int i = 0; i < buttonArray.Length; i++)
            {
                Debug.Log($"Initialized { buttonArray[i]}.");
            }
            winObject.SetActive(false);
        }
        public void checkOnClick()
        {
            // Array for results
            bool[] results = new bool[8];
            bool[] resultsO = new bool[8];


            // Check if the button is 1 (X)
            results[0] = AreValuesEqual(1, b1.thisButtonIs, b2.thisButtonIs, b3.thisButtonIs); // 123 horizontal
            results[1] = AreValuesEqual(1, b4.thisButtonIs, b5.thisButtonIs, b6.thisButtonIs); // 456 horizontal
            results[2] = AreValuesEqual(1, b7.thisButtonIs, b8.thisButtonIs, b9.thisButtonIs); // 789 horizontal
            results[3] = AreValuesEqual(1, b1.thisButtonIs, b4.thisButtonIs, b7.thisButtonIs); // 147 vertical
            results[4] = AreValuesEqual(1, b2.thisButtonIs, b5.thisButtonIs, b8.thisButtonIs); // 258 vertical
            results[5] = AreValuesEqual(1, b3.thisButtonIs, b6.thisButtonIs, b9.thisButtonIs); // 369 vertical
            results[6] = AreValuesEqual(1, b3.thisButtonIs, b5.thisButtonIs, b7.thisButtonIs); // 357 diagonal
            results[7] = AreValuesEqual(1, b1.thisButtonIs, b5.thisButtonIs, b9.thisButtonIs); // 159 diagonal

            // Check if button is 2 (O)
            resultsO[0] = AreValuesEqual(2, b1.thisButtonIs, b2.thisButtonIs, b3.thisButtonIs); // 123 horizontal
            resultsO[1] = AreValuesEqual(2, b4.thisButtonIs, b5.thisButtonIs, b6.thisButtonIs); // 456 horizontal
            resultsO[2] = AreValuesEqual(2, b7.thisButtonIs, b8.thisButtonIs, b9.thisButtonIs); // 789 horizontal
            resultsO[3] = AreValuesEqual(2, b1.thisButtonIs, b4.thisButtonIs, b7.thisButtonIs); // 147 vertical
            resultsO[4] = AreValuesEqual(2, b2.thisButtonIs, b5.thisButtonIs, b8.thisButtonIs); // 258 vertical
            resultsO[5] = AreValuesEqual(2, b3.thisButtonIs, b6.thisButtonIs, b9.thisButtonIs); // 369 vertical
            resultsO[6] = AreValuesEqual(2, b3.thisButtonIs, b5.thisButtonIs, b7.thisButtonIs); // 357 diagonal
            resultsO[7] = AreValuesEqual(2, b1.thisButtonIs, b5.thisButtonIs, b9.thisButtonIs); // 159 diagonal


            // Check results for X
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i])
                {
                    win = true;
                    Debug.Log($"X YOU WON {i + 1}");
                    winObject.SetActive(true);
                    winText.text = "Player X is the Winner!";
                    canvasGroup.interactable = false;
                    return;
                }
            }

            // Check resultsO for O
            for (int i = 0; i < resultsO.Length; i++)
            {
                if (resultsO[i])
                {
                    win = true;
                    Debug.Log($"O YOU WON {i + 1}");
                    winObject.SetActive(true);
                    winText.text = "Player O is the Winner!";
                    canvasGroup.interactable = false;
                    return;
                }
            }
            //check if all pressed but both lost
            if (TicTakButton.num == 10) // On ninth click and no win was triggered before all lost
            {
                win = false;
                Debug.Log("All lost");
                winObject.SetActive(true);
                winText.text = "All Lost! Try Again?";
            }
        }
    }
}
    
