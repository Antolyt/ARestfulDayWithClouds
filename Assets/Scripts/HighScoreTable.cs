using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HighScoreTable : MonoBehaviour {

    public NameScore[] nameScores;
    public GameObject inputField;
    public Text inputFieldName;
    public EventSystem es;

    public UnityEvent actionOnSubmit;

    void Start()
    {
        bool inputPlaced = false;

        for(int i = 0, j = 0; i <= nameScores.Length; i++)
        {
            if(j < SaveScore.scoreData.scoreNames.Count)
            {
                if(!inputPlaced && SaveScore.currentScore >= SaveScore.scoreData.scoreNames[i].score)
                {
                    inputField.transform.position = nameScores[i].name.transform.position;
                    es.SetSelectedGameObject(inputField);
                    nameScores[i].name.text = "";
                    inputPlaced = true;
                }
                else
                {
                    nameScores[i].name.text = SaveScore.scoreData.scoreNames[j].name;
                    nameScores[i].score.text = SaveScore.scoreData.scoreNames[j].score.ToString();
                    j++;
                }
            }
            else if(!inputPlaced)
            {
                inputField.transform.position = nameScores[i].name.transform.position;
                es.SetSelectedGameObject(inputField);
                nameScores[i].name.text = "";
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SaveScore.AddPlayerToScoreTable(inputFieldName.text);
            if (actionOnSubmit != null) actionOnSubmit.Invoke();
            return;
        }
    }
}

[Serializable]
public struct NameScore
{
    public Text name;
    public Text score;
}
