using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheMuseum.Biography.Proxy;

public class BindingProxy : Freezable
{
    // Используется для определения зависимого свойства, к которому будет привязано значение
    public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
        "Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));

    public object Data
    {
        get => GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    protected override Freezable CreateInstanceCore()
    {
        return new BindingProxy();
    }
}
