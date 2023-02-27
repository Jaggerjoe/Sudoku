using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region References
    [SerializeField] GameObject m_SubGrid = null;
    [SerializeField] GameObject m_Prefab = null;
    [SerializeField] GameObject m_CaseNumberPrefab = null;
    [SerializeField] Transform m_Parent = null;
    [SerializeField] Grid m_Grid = null;
    [SerializeField] SudokuGenerator m_SudokuGenerator = null;
    [SerializeField] DataLevel m_DataLevel = null;

    private GameObject[,] m_SubGridObject = new GameObject[3, 3];
    private GameObject[,] m_CaseNumberObject = new GameObject[3, 3];
    private GameObject[,] m_SubCaseNumberObject = new GameObject[3, 3];
    #endregion

    #region Properties
    public Grid MyGrid { get { return m_Grid; } set { m_Grid = value; } }
    #endregion

    private void OnEnable()
    {
        CreateSubGrid();
        StartCoroutine(m_SudokuGenerator.CreateSUdokuGrid());
    }

    private void Start()
    {
    }

    void CreateSubGrid()
    {
        int l_Num = 1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_SubGridObject = Instantiate(m_SubGrid, m_Parent.position, Quaternion.identity, m_Parent);
                m_SubGridObject[i, j] = l_SubGridObject;
                l_SubGridObject.name = "Subgrid " + l_Num;
                InstantiateCaseNumber(l_SubGridObject);

                l_Num++;
            }
        }
    }

    void InstantiateCaseNumber(GameObject p_SubGridObject)
    {
        int t = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_Case = Instantiate(m_Prefab, m_Parent.position, Quaternion.identity, p_SubGridObject.transform);
                m_CaseNumberObject[i, j] = l_Case;
                l_Case.name = "Case " + t;
                t++;

                CreateSubCaseNumber(l_Case);
            }
        }
    }

    void CreateSubCaseNumber(GameObject p_Case)
    {
        int l_Num = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_SubCaseNumber = Instantiate(m_CaseNumberPrefab, p_Case.transform.Find("SubCaseNumber"));
                m_SubCaseNumberObject[i, j] = l_SubCaseNumber;
                Text l_Text = l_SubCaseNumber.GetComponentInChildren<Text>();
                l_Text.text = (l_Num).ToString();
                l_Num++;
            }
        }
    }

    public void AddGameObject(Grid p_Grid)
    {
        AddSubCaseGameObject(p_Grid);
    }

    private void AddSubCaseGameObject(Grid p_Grid)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_Grid.SubGridArray[i, j].SubGridObject = m_SubGridObject[i, j];
                AddGameObjectCaseNumber(p_Grid.SubGridArray[i, j]);
            }
        }
    }

    private void AddGameObjectCaseNumber(SubGrid p_SubGrid)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_SubGrid.CaseNumber[i, j].Case = m_CaseNumberObject[i, j];
                p_SubGrid.CaseNumber[i, j].GridSubCaseNumber = m_CaseNumberObject[i, j].GetComponentInChildren<GridLayoutGroup>().gameObject;
                p_SubGrid.CaseNumber[i, j].Text = m_CaseNumberObject[i, j].GetComponentInChildren<Text>();
                AddGameObjectToSubCaseNumber(p_SubGrid.CaseNumber[i, j]);
            }
        }
    }

    private void AddGameObjectToSubCaseNumber(CaseNumber p_CaseNumber)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_CaseNumber.SubCaseNumber[i, j].SelfSubCaseNumber = m_SubCaseNumberObject[i, j];
                p_CaseNumber.SubCaseNumber[i,j].Button = m_SubCaseNumberObject[i,j].GetComponent<Button>();
                p_CaseNumber.SubCaseNumber[i,j].Image = m_SubCaseNumberObject[i,j].GetComponent<Image>();
                m_SubCaseNumberObject[i, j].GetComponent<Button>().onClick.AddListener(p_CaseNumber.SubCaseNumber[i, j].AddListenerToButton);
            }
        }
    }
}
