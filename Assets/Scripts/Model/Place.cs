public class Place
{
    private int jumpIndex;

    public Place(int jumpIndex)
    {
        this.jumpIndex = jumpIndex;
    }

    public int JumpTo
    {
        get
        {
            return jumpIndex;
        }
    }
}