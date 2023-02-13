using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_Prefab = null;
    [SerializeField] GameObject m_CaseNumberPrefab = null;
    [SerializeField] Transform m_Parent = null;
    [SerializeField] private List<CaseNumber> m_CaseNumber;

    private void OnEnable()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject l_Case = Instantiate(m_Prefab, m_Parent.position, Quaternion.identity, m_Parent);
                //creation des nombre par case
                CaseNumber l_Number = new CaseNumber(l_Case);
                m_CaseNumber.Add(l_Number);
            }
        }
        CreateCaseNumber();
    }

    void CreateCaseNumber()
    {
        for (int i = 0; i < m_CaseNumber.Count; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject l_CaseNumber = Instantiate(m_CaseNumberPrefab, m_CaseNumber[i].Case.transform);
                Text l_Text = l_CaseNumber.GetComponentInChildren<Text>();
                l_Text.text = (j + 1).ToString();
            }
        }
    }
}
