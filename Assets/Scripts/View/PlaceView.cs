using UnityEngine;

namespace SnakesAndLadders
{
    public class PlaceView : MonoBehaviour
    {
        public int Id;
        public TextMesh Label;

        // In the case of a Snake or Ladder, allow the designer
        //  to specify which place to jump to
        public PlaceView JumpTo;

        public int JumpToId
        {
            get
            {
                return JumpTo != null ? JumpTo.Id : 0;
            }
        }

        public void Init(int id)
        {
            Id = id;
            Label.text = (id + 1).ToString();
        }
    }
}