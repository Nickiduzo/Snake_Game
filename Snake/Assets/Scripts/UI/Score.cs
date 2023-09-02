using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI mainText;
    static public int counter;
    private void Start()
    {
        mainText = GetComponent<TextMeshProUGUI>();
        counter = 0;
    }
    private void Update()
    {
        mainText.text = counter.ToString();
        Debug.Log(mainText.text);
    }

    static public void IncreaseScore()
    {
        counter++;
    }
    static public void DecreaseScore()
    {
        counter--;
    }
    static public int ReturnScore()
    {
        return counter;
    }
}
