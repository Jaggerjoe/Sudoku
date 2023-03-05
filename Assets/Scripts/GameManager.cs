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
    [SerializeField] SudokuGenerator m_SudokuGenerator = null;

    GridSudoku m_Grid = null;

    private GameObject[,] m_SubGridObject = new GameObject[3, 3];
    private List<GameObject[,]> m_CaseNumberObject = new List<GameObject[,]>();
    private List<GameObject[,]> m_SubCaseNumberObject = new List<GameObject[,]>();
    private List<GameObject> m_GmGridLayout = new List<GameObject>();
    int m_Index = 0;

    #endregion

    #region Properties
    public GridSudoku MyGrid { get { return m_Grid; } set { m_Grid = value; } }
    #endregion

    private void OnEnable()
    {
        CreateSubGrid();
        StartCoroutine(m_SudokuGenerator.CreateSudokuGrid());
    }

    private void Start()
    {
    }

    public void CreateSubGrid()
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
        GameObject[,] l_CaseNumbersArray = new GameObject[3,3];   
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_Case = Instantiate(m_Prefab, m_Parent.position, Quaternion.identity, p_SubGridObject.transform);
                l_CaseNumbersArray[i, j] = l_Case;
                l_Case.name = "Case " + t;
                t++;

                CreateSubCaseNumber(l_Case);
            }
        }
        m_CaseNumberObject.Add(l_CaseNumbersArray);
    }

    void CreateSubCaseNumber(GameObject p_Case)
    {
        int l_Num = 1;
        GameObject[,] l_SubCaseNumbersArray = new GameObject[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject l_SubCaseNumber = Instantiate(m_CaseNumberPrefab, p_Case.transform.Find("SubCaseNumber"));
                l_SubCaseNumbersArray[i, j] = l_SubCaseNumber;
                Text l_Text = l_SubCaseNumber.GetComponentInChildren<Text>();
                l_Text.text = (l_Num).ToString();
                l_Num++;
            }
        }
        m_SubCaseNumberObject.Add(l_SubCaseNumbersArray);
    }

    public void AddGameObject(GridSudoku p_Grid)
    {
        m_Index = 0;
        AddSubGridGameObject(p_Grid);
    }

    private void AddSubGridGameObject(GridSudoku p_Grid)
    {
        Debug.Log(p_Grid);
        int l_Index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_Grid.SubGridArray[i, j].SubGridObject = m_SubGridObject[i, j];
                AddCaseNumberObject(p_Grid.SubGridArray[i, j],m_CaseNumberObject[l_Index]);
                l_Index++;
            }
        }
    }

    private void AddCaseNumberObject(SubGrid p_SubGrid,GameObject[,] p_CaseArray)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_SubGrid.CaseNumber[i, j].Case = p_CaseArray[i, j];
                p_SubGrid.CaseNumber[i, j].GridSubCaseNumber = p_CaseArray[i, j].GetComponentInChildren<GridLayoutGroup>().gameObject;
                m_GmGridLayout.Add(p_CaseArray[i, j].GetComponentInChildren<GridLayoutGroup>().gameObject);
                p_SubGrid.CaseNumber[i, j].Text = p_CaseArray[i, j].GetComponentInChildren<Text>();
                AddGameObjectToSubCaseNumber(p_SubGrid.CaseNumber[i, j], m_SubCaseNumberObject[m_Index]);
                m_Index++;
            }
        }
    }

    private void AddGameObjectToSubCaseNumber(CaseNumber p_CaseNumber, GameObject[,] p_SubCaseNumberObject)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_CaseNumber.SubCaseNumber[i,j].SelfSubCaseNumber = p_SubCaseNumberObject[i,j];
                p_CaseNumber.SubCaseNumber[i,j].Button = p_SubCaseNumberObject[i,j].GetComponent<Button>();
                p_CaseNumber.SubCaseNumber[i,j].Image = p_SubCaseNumberObject[i,j].GetComponent<Image>();
                p_SubCaseNumberObject[i,j].GetComponent<Button>().onClick.AddListener(p_CaseNumber.SubCaseNumber[i, j].AddListenerToButton);
            }
        }
    }
}
