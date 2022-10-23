using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    
    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();//permet de lancer le changement de scène 
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));//Exécute la prochaine phrase
        personNameText.text=currentScene.sentences[sentenceIndex].speaker.speakerName;//affichage du nom du locuteur et de sa couleur
        personNameText.color=currentScene.sentences[sentenceIndex].speaker.Color;
        
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.02f);//affiche les lettres avec un delai
            if(++wordIndex == text.Length)//si l'élément correspond au dernier élément de la phrase, elle est considérée comme achevée.
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
