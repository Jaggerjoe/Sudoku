using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MainGrid m_Grid = null;

    private void OnEnable()
    {
        MainGrid l_grid = new MainGrid();
        m_Grid = l_grid;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
