   M S B A M L   `   `   `  ����b  ^HotBag.AspNetCore.PrinterServiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFUI.ViewsWPFUI.Views  5      &     WPFUI.Views.AppConfigurationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPFUI.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6"   .+�5      �� $��Center=�5      $��Center=�5      $��
0 20 30 20q�5      $
��Wrap=�5       $��25(�5!      APP CONFIGURATION WIZARD5#      5$      �� 5'   
   $��2��6   $��1��6"   .+�5(      ��  �� Orientation$ Vertical=�6   .+�5)      �� $��15(�6   $
��Bold"�6&   .��68   Service Name6F   �� 5*      -   5         ��Name$ AppConfig_ServiceName��5*      $��Center=�5+      $��15(�5,      $��25��5-      5.      �� 50      $ Vertical=�6   .+�51      �� $��15(�6   $
��Bold"�6&   .��68   Service Display Name6N   �� 52      -   5        $" AppConfig_ServiceDisplayName��52      $��Center=�53      $��15(�54      $��25��55      56      �� 58      $ Vertical=�6   .+�59      �� $��15(�6   $
��Bold"�6&   .��68   #!Service Executable file Directory6[   �� 5:      -   5        $! AppConfig_InstallerLocation��5:      $��Center=�5;      $��15(�5<      $��25��5=      5>      �� 5@      $ Vertical=�6   .+�5A      �� $��15(�6   $
��Bold"�6&   .��68    Service Installation Directory6X   �� 5B      -   5        $$ AppConfig_InstallationLocation��5B      $��Center=�5C      $��15(�5D      $��25��5E      5F      �� 5H      $ Vertical=�6   .+�5I      �� $��15(�6   $
��Bold"�6&   .��68   Printer Setup Directory6Q   �� 5J      -   5        $' !AppConfig_PrinterSettingDirectory��5J      $��Center=�5K      $��15(�5L      $��25��5M      5N      5P      �� 5R   
   $��3��6   $��1��6"   .+�5S      �� $��Center=�5T      $��Center=�5U       �� TextAlignment$ Center=�5V      $��10 20 30 10q�5W      $
��Wrap=�5X      $��18(�5Y      ECAre you sure to update application configuration? Confirm to "YES".5[      5\      �� 5_   
   $��4��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   .+�5`      �� -   5         ��Name$ UpdateConfig��5`      $��5q�6+   $��5q�66   $��40��6B   .��5a      �� $��10q�6   $��15(�6(    YES, Confirm and Update Config6V   5b      �� 5c      -   5        $ 	ResetForm��5c      $��5q�6(   $��5q�63   $��40��6?   .��5d      �� $��10q�6   $��15(�6(   Reset6=   5e      �� 5f      -   5        $ ResetToDefault��5f      $��5q�6-   $��5q�68   $��40��6D   .��5g      �� $��10q�6   $��15(�6(   Reset to Default6H   5h      5i      5l      5m      