using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public CloudSpawner cloudSpawner;
    string[] questElements;
    string questElement;
    public Text questText;

    public Text scoreText;
    public int basicScore;
    int score;
    public int chainMultiplier;
    int chain;
    public int maxChain = 50;

    public AudioSource correct;
    public AudioSource incorrect;

    public string[] sentenceBegin = { "Do you see this ", "Aww, this ", "This ", "I see a ", "When I go home maybe I buy this ", "Look at this " };
    public string[] sentenceEnd = { ".", " is beautiful.", " reminds me of somthing.", ", you too?", ".", "." };

    public ScorePresenter scorePresenter;

    // Use this for initialization
    void Start ()
    {
        questElements = new string[cloudSpawner.cloudVariants.Length];
        for(int i = 0; i < questElements.Length; i++)
        {
            questElements[i] = cloudSpawner.cloudVariants[i].name.Split('_')[1];
        }

        NewQuest();
	}
	
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Chain</returns>
    public int RateElement(string name)
    {
        if(name == questElement)
        {
            score += basicScore + chain * chainMultiplier;
            scoreText.text = score.ToString();

            chain = chain < maxChain ? chain + 1 : maxChain;
            correct.Play();

            NewQuest();
        }
        else
        {
            chain = 0;
            incorrect.Play();
        }

        return chain;
    }

    public void NewQuest()
    {
        questElement = questElements[Random.Range(0, questElements.Length)];
        int sentence = Random.Range(0, sentenceBegin.Length);
        string quest = sentenceBegin[sentence] + "<b>" + questElement + "</b>";
        if (sentence > sentenceEnd.Length)
            sentence = 0;
        questText.text = quest + sentenceEnd[sentence];
    }

    public void PresentScore()
    {

    }
}
