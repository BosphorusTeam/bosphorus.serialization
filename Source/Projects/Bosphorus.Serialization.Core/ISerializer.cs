using System;

namespace Bosphorus.Serialization.Core
{
    public interface ISerializer
    {
        string Serialize(object model);

        object Deserialize(Type type, string input);
    }
}
