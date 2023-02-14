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
        CreateCaseNumber();
    }

    private void Update()
    {
       
    }

    void GetCaseNumber()
    {
       
    }

    void CreateCaseNumber()
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
        CreateSubCaseNumber();
    }

    void CreateSubCaseNumber()
    {
        for (int i = 0; i < m_CaseNumber.Count; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //Class pour l'index ?
                GameObject l_SubCaseNumber = Instantiate(m_CaseNumberPrefab, m_CaseNumber[i].Case.transform.Find("SubCaseNumber"));
                l_SubCaseNumber.GetComponent<Button>().onClick.AddListener(GetCaseNumber);
                CaseSubNumber l_CseSub = l_SubCaseNumber.GetComponent<CaseSubNumber>();
                l_CseSub.CaseParent = m_CaseNumber[i].Case;
                l_CseSub.Number = j + 1;
                Text l_Text = l_SubCaseNumber.GetComponentInChildren<Text>();
                l_Text.text = (j + 1).ToString();
                m_CaseNumber[i].SubCaseNumber[j] = l_SubCaseNumber;
            }
        }
    }
}
