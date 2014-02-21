namespace ColdBeer.Classes.PingList
{
    public interface IPingList
    {
        int Length();

        void Add(long time);

        long PingAt(int index = -1);

        string ToBinary(int from, int to = -1);
    }
}
