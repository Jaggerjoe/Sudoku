//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class MainGrid 
//{
//    [SerializeField] List<SubGrid> m_Subgrids = new List<SubGrid> ();
//    private GameObject m_SubGrid = null;
//    // Start is called before the first frame update
//    public MainGrid(GameObject p_SubGrid, Transform p_Parent)
//    {
//        //m_SubGrid = p_SubGrid;
//        CreateGrid (p_SubGrid, p_Parent);
//    }
//    void CreateGrid(GameObject p_SubGrid, Transform p_Parent)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                //Creation des SubGrids
//                SubGrid l_SubGrid = new SubGrid(i,j, m_SubGrid);
//                m_Subgrids.Add (l_SubGrid);
//                GameObject l_Gm = new GameObject();
//                l_Gm.transform.parent = p_Parent;
//                l_Gm = m_SubGrid;

//            }
//        }
//    }
//}
