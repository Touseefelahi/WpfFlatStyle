namespace FlatStyle
{
    public class GetCommand : BaseAttachedProperty<GetCommand, ParameterizedDelegateCommand> { }

    public class SetCommand : BaseAttachedProperty<SetCommand, ParameterizedDelegateCommand> { }

    public class SetText : BaseAttachedProperty<SetText, string> { }

    public class GetText : BaseAttachedProperty<GetText, string> { }
}