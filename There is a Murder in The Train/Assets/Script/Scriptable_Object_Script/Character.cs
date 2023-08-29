using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Character")]
[System.Serializable]
public class Character : ScriptableObject
{
    public string characterName;
    //public Image characterBody;
    public List<ExpressionData> characterExpression;

    [System.Serializable]
    public class ExpressionData
    {
        public string expressionType;
        public Sprite expressionImage;
    }
    public ExpressionData GetExpressionData(string expressionType)
    {
        return characterExpression.Find(e => e.expressionType == expressionType);
    }
}
