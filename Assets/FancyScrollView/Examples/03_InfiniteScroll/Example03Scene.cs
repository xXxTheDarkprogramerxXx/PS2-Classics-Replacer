using System.Linq;
using UnityEngine;

namespace FancyScrollView
{
    public class Example03Scene : MonoBehaviour
    {
        [SerializeField]
        Example03ScrollView scrollView;

        void Start()
        {
			/*Load PS2 Database*/
			/*Should have most of the names of games might miss a few but thats okay*/



            var cellData = Enumerable.Range(0, 20)
                .Select(i => new Example03CellDto { Message = "Cell " + i })
                .ToList();

            scrollView.UpdateData(cellData);
        }
    }
}
