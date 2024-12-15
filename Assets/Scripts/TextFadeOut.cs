using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private TMP_Text popUpText;
    [SerializeField] float fadeDuration = 1.5f;

    [SerializeField] Canvas textCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //popUpText = GetComponent<TMP_Text>();
    }

    //Method to allow for custom messages / colour
    public void TextSetUp(string message, Color textColour)
    {
        popUpText.text = message; //Set the TMP text to whatever the message is 
        popUpText.color = textColour; //Set the colour to whatever colour there is

        //Call the ienumator here

        StartCoroutine(textFadeOut());
    }

    //Create Ienumator to handle the fade out

    public IEnumerator textFadeOut()
    {   
        float elapsedTime = 0f;
        //Set the starting colour
        Color startingColour = popUpText.color;

        while(elapsedTime < fadeDuration) //Checks to see if the elapsed time is less than the fade our duration time
        {
            //Code here
            elapsedTime += Time.deltaTime;
            //Float to handle the alpha of the text
            float textAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            popUpText.color = new Color(startingColour.r, startingColour.g, startingColour.b, textAlpha);
            yield return null;
        }

        //Destroy(this.gameObject); //Destory the text object afterwards
    }
}
