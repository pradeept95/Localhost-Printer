   M S B A M L   `   `   `  ����b  ^HotBag.AspNetCore.PrinterServiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFUI.ViewsWPFUI.Views  5          WPFUI.Views.InstallView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPFUI.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6"   .+�5      �� $��Center=�5      $��Center=�5      $��	0 20 30 0q�5      $
��Wrap=�5       $��25(�5!      SERVICE INSTALL WIZARD5#      5$      �� 5%   
   $��2��6   $��1��6#    �� Orientation$ 
Horizontal=�63   .+�5&      �� -   5         ��Name$ SelectedFileName��5,       �� TextWrapping$
 Wrap=�5'       �� AcceptsReturn$
 True��5(      $ �� HorizontalScrollBarVisibility$ Disabled=�5)      " �� VerticalScrollBarVisibility$
 Auto=�5*       �� 
IsReadOnly$
 True��5+      $	��300��5-      $��30��5.      �� 50      -   5        	 ��Name$	 SelectInstaller��50      $��5q�6.   $��5q�69   $��40��6E   .��51      �� $��10q�6   $��15(�6(   Select service Installer6P   52      53      �� 55   
   $��3��6   $��1��6"   .+�56      �� $��Center=�57      $��Center=�58      
 �� TextAlignment$
 Center=�59      $��10 20 30 10q�5:      $
��Wrap=�5;      $��18(�5<      42Are you sure to install service? Confirm to "YES".5>      5?      �� 5A   
   $��4��6   $��1��6"   .+�5B      �� -   5        $	 InstallService��5B      $��5q�6-   $��5q�68   $��40��6D   .��5C      �� $��10q�6   $��15(�6(   YES, Confirm and Install6P   5D      5E      �� 5F   
   $��5��6   $��1��6"   .+�5G      �� -   5        $ ResultViewer��5M      $
 Wrap=�5H      $
 True��5I      $ Disabled=�5J      $
 Auto=�5K      $
 True��5L      $	��300��5N      5P      5R      5S      