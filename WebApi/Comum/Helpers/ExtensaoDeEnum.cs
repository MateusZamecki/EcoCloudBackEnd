using System;
using System.ComponentModel;

namespace Comum.Helpers;

public static class ExtensaoDeEnum
{
    public static string ObterDescricaoDaEnumeracao(this Enum value)
    {
        var attribute = value._obterAtributosDaEnum<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

    private static T _obterAtributosDaEnum<T>(this Enum value) where T : Attribute
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return (T)attributes[0];
    }
}
