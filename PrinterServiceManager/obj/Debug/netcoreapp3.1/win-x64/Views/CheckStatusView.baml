   M S B A M L   `   `   `  ����b  ^HotBag.AspNetCore.PrinterServiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFUI.ViewsWPFUI.Views  5      !    WPFUI.Views.CheckStatusView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPFUI.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6"   .+�5      �� $��Center=�5      $��Center=�5      $��	0 20 30 0q�5      $
��Wrap=�5       $��25(�5!      CHECK SERVICE STATUS WIZARD5#      5$      �� 5&   
   $��2��6   $��1��6"   .+�5'      �� $��Center=�5(      $��Center=�5)       �� TextAlignment$ Center=�5*      $��10 20 30 10q�5+      $
��Wrap=�5,      $��18(�5-      <:Are you sure to check status of service? Confirm to "YES".5/      50      �� 52   
   $��3��6   $��1��6"   .+�53      �� -   5         ��Name$ ServiceCheckStatus��53      $��5q�61   $��5q�6<   $��40��6H   .��54      �� $��10q�6   $��15(�6(   YES, Confirm and Check Status6U   55      56      �� 57   
   $��4��6   $��1��6"   .+�58      �� -   5         ��Name$ ResultViewer��5>       �� TextWrapping$
 Wrap=�59       �� AcceptsReturn$
 True��5:      $ �� HorizontalScrollBarVisibility$ Disabled=�5;      " �� VerticalScrollBarVisibility$
 Auto=�5<      	 �� 
IsReadOnly$
	 True��5=      $	��300��5?      5A      5C      5D      