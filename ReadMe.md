# Use this text in your App.xaml file

    <Application.Resources>
           <ResourceDictionary>
               <ResourceDictionary.MergedDictionaries>
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Colors.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Fonts.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/BaseStyle.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Icons.xaml" />                
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/IconsSolid.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Button.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/ButtonIconBased.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Text.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Scroll.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/Datagrid.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/ComboBox.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/CheckBox.xaml" />                
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/ProgressBar.xaml" />                       
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/TabControl.xaml" />
                   <ResourceDictionary Source="pack://application:,,,/FlatStyle;component/Style/WindowStyle.xaml" />
               </ResourceDictionary.MergedDictionaries>
           </ResourceDictionary>
     </Application.Resources>


 # Set Style As flat window
 
        <Window x:Class="FlatStyle.Sample.MainWindow"      
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"        
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"        
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"        
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"        
        xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit"        
        mc:Ignorable="d" 
        xmlns:flatStyle="clr-namespace:FlatStyle;assembly=FlatStyle"   
        Style="{StaticResource FlatWindow}"
        flatStyle:TitleBar.Value="30"
        Title="MainWindow" Height="450" Width="800">
        
 # Sample
 
 Light Theme: 
![alt text](https://github.com/Touseefelahi/WpfFlatStyle/blob/master/BlueLightTheme.png " Light Theme")
 
Dark Theme: 
![alt text](https://github.com/Touseefelahi/WpfFlatStyle/blob/master/BlueDarkTheme.png " Dark Theme")

# Quick Hints
+ [Button](https://github.com/Touseefelahi/WpfFlatStyle#button)
+ [Toggle Button](https://github.com/Touseefelahi/WpfFlatStyle#Toggle button)
+ [CheckBox](https://github.com/Touseefelahi/WpfFlatStyle#checkbox)

# Button


# Toggle Button

# CheckBox





