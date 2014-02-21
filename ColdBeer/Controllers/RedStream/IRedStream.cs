using ColdBeer.Components.Red;
using System.Collections;

namespace ColdBeer.Controllers.RedStream
{
    public delegate void RedStreamReceivedEventHandler(string data);

    public interface IRedStream
    {
        event RedStreamReceivedEventHandler Command;

        void Connect(IRed red);
    }
}
