using System.Collections;
using System.Text;

namespace ColdBeer.Classes.RedDataList
{
    /// <summary>
    /// List - Contains a collection of IR signals received
    /// </summary>
    public class RedDataList
    {
        private ArrayList _redData = new ArrayList();

        /// <summary>
        /// add a new redData item to the collection
        /// </summary>
        /// <param name="redData"></param>
        public void Add(RedData redData)
        {
            _redData.Add(redData);
        }

        /// <summary>
        /// clear the list to get back to a blank slate
        /// </summary>
        public void Reset()
        {
            _redData.Clear();
        }

        /// <summary>
        /// return the number of items in the list
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return _redData.Count;
        }

        /// <summary>
        /// return a IR recorded at the speciffic index
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public RedData ItemAt(int x)
        {
            return (RedData)_redData[x];
        }

        /// <summary>
        /// binary representation of the received data
        /// </summary>
        /// <returns></returns>
        public string ToBinary()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i <= _redData.Count; i++)
            {
                result.Append(((RedData)_redData[i]).State ? 1 : 0);
            }

            return result.ToString();
        }
    }
}
