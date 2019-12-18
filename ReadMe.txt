 

 Use this text in your App.xaml file
 
 <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Order is important -->
				
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Colors.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/BaseStyle.xaml" />                
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Icons.xaml" />

                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Button.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/ButtonIconBased.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Text.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Scroll.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Datagrid.xaml" />
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/ComboBox.xaml" />				
                <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/CheckBox.xaml" />

            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
  </Application.Resources>


  For Chrome window use this:
  //Xaml
    <Window.Resources>
      <Style TargetType="{x:Type TextBlock}">
            <Setter Property="Foreground" Value="{DynamicResource ForegroundMainBrush}" />
        </Style>
        <Style TargetType="{x:Type local:MainWindow}">
            <Setter Property="WindowChrome.WindowChrome">
                <Setter.Value>
                    <WindowChrome />
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:MainWindow}">
                        <Grid>
                            <Border Background="{StaticResource PrimaryBrush}">
                                <ContentPresenter Content="{TemplateBinding Content}" />
                            </Border>
                            <TextBlock Text="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Title}"
                               VerticalAlignment="Top" HorizontalAlignment="Left" Foreground="{StaticResource ControlForegroundBrush}" FontWeight="Black"
                               Margin="12,8,0,0" />
                            <Image Source="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Icon}" VerticalAlignment="Top" HorizontalAlignment="Left" WindowChrome.IsHitTestVisibleInChrome="True" />
                            <StackPanel Orientation="Horizontal" VerticalAlignment="Top" HorizontalAlignment="Right">
                                <Button Content="_" Style="{StaticResource WindowButton}" Click="MinimizeWindow" />
                                <Button Content="☐" Style="{StaticResource WindowButton}" Click="MaximizeWindow" />
                                <Button Content="X" Style="{StaticResource WindowButton}" Click="CloseWindow" />
                            </StackPanel>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>

	//Code Behind
	  private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

      private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

      private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;

                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;
            }
        }