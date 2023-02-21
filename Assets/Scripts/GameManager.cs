using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_SubGrid = null;
    [SerializeField] GameObject m_Prefab = null;
    [SerializeField] GameObject m_CaseNumberPrefab = null;
    [SerializeField] Transform m_Parent = null;
    //[SerializeField] private List<CaseNumber> m_CaseNumber;

    [SerializeField] List<SubGrid> m_SubGird = new List<SubGrid>();

    private SubGrid[,] m_SubGridArray = new SubGrid[3, 3];

    private void OnEnable()
    {
        CreateSubGrid();
    }
    void CreateSubGrid()
    {
        int l_Num = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_SubGridObject = Instantiate(m_SubGrid, m_Parent.position, Quaternion.identity, m_Parent);
                l_SubGridObject.name = "Subgrid " + l_Num;
                l_Num++;
                SubGrid l_NewSubGrid = new SubGrid(l_SubGridObject);
                m_SubGridArray[i, j] = l_NewSubGrid;
                if(m_SubGridArray[i,0] != null)
                    Debug.Log(m_SubGridArray[i,0].SubGridObject);
                m_SubGird.Add(l_NewSubGrid);
            }
        }
        CreateCaseNumber();
    }

    void CreateCaseNumber()
    {
        foreach (var item in m_SubGird)
        {
            InstantiateCaseNumber(item);
        }
    }
    void InstantiateCaseNumber(SubGrid p_SubGrid)
    {
        int t = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_Case = Instantiate(m_Prefab, m_Parent.position, Quaternion.identity, p_SubGrid.SubGridObject.transform);
                GameObject l_SubGrid = l_Case.GetComponentInChildren<GridLayoutGroup>().gameObject;
                Text l_Text = l_Case.GetComponentInChildren<Text>();
                l_Case.name = "Case " + t;
                t++;
                //creation des nombre par case
                CaseNumber l_Number = new CaseNumber(l_Case, l_SubGrid,l_Text, p_SubGrid);
                p_SubGrid.CaseNumber[i, j] = l_Number;
                p_SubGrid.CaseDebug.Add(l_Number);
                CreateSubCaseNumber(l_Number);
            }
        }
    }

    void CreateSubCaseNumber(CaseNumber p_CaseNum)
    {
        int l_Num = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_SubCaseNumber = Instantiate(m_CaseNumberPrefab, p_CaseNum.Case.transform.Find("SubCaseNumber"));
                Text l_Text = l_SubCaseNumber.GetComponentInChildren<Text>();
                l_Text.text = (l_Num).ToString();
                CaseSubNumber l_CaseSub = new CaseSubNumber(l_Num, l_SubCaseNumber, p_CaseNum);
                l_Num++;
                l_SubCaseNumber.GetComponent<Button>().onClick.AddListener(l_CaseSub.AddListenerToButton);
                p_CaseNum.SubCaseNumber[i, j] = l_CaseSub;
                p_CaseNum.SubDebug.Add(l_CaseSub);
            }
        }
    }
}
