﻿namespace Bosphorus.Serialization.Core
{
    //TODO: Deserializer için default implementation type'ları register edilebilmeli
    //TODO: Nedense Oğuz abinin modeli nhibernate te persist edilemiyor, Oracle için
    public interface IJsonSerializer<TModel> : ISerializer<TModel>
    {
    }
}
