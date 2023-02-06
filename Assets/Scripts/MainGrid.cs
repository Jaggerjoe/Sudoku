using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainGrid 
{
    [SerializeField] List<SubGrid> m_Subgrids = new List<SubGrid> ();
    // Start is called before the first frame update
    public MainGrid()
    {
        CreateGrid ();
    }
    void CreateGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                //Creation des SubGrids
                SubGrid m_SubGrid = new SubGrid();
                m_Subgrids.Add (m_SubGrid);
            }
        }
    }
}
