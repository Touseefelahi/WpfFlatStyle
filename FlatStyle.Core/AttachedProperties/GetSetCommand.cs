using System.Windows.Input;

namespace FlatStyle
{
    /// <summary>
    /// Get command will be invoked whenever Get button is pressed from GetSetField Textbox
    /// </summary>
    public class GetCommand : BaseAttachedProperty<GetCommand, ICommand> { }

    /// <summary>
    /// Set command will be invoked whenever Set button is pressed from GetSetField Textbox
    /// </summary>
    public class SetCommand : BaseAttachedProperty<SetCommand, ICommand> { }

    public class SetText : BaseAttachedProperty<SetText, string> { }

    public class GetText : BaseAttachedProperty<GetText, string> { }
}