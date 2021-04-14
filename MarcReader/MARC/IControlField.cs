using System;

namespace MarcReader.MARC
{
    public interface IControlField : IVariableField
    {
        String Data { get; set; }
    }
}