   M S B A M L   `   `   `  ����b  ^HotBag.AspNetCore.PrinterServiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFUI.ViewsWPFUI.Views  5   	       WPFUI.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFUI.Views     5   	     � Title$  	ShellView��5   	    � 
ResizeMode$ CanMinimize=�5	   	   $��	Helvetica)�5
   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState 5   	   �� *AppWindowState+ �� Mode$ TwoWay=���5   	   �� *&$SystemParameters.PrimaryScreenHeight+��5   	   �� *%#SystemParameters.PrimaryScreenWidth+.��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��600 �6   �� 5      $��* �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $��* �6   �� 5!      $��20 �6   .+�5$   
   ��  �� CornerRadius$ 0��6   $��8��6"   $��6��63   ��5%      �� 5&      .��5'      � 	 � Color$	 #7be9f6��6#   
 � Offset$	
 0.0Q�63   � 5(      $	 #f083da��6#   $
 1Q�63   5)      5+      �� 5.   
   $��0��6   $��0��6"   $��2��62   $��8��6F   ��5/      �� 50       �� ImageSource$ bg.png��6    j� Stretch$ UniformToFill=�62   53      �� 57   
   -   5         ��Name$ CloseWindow��57      $��0��6&   $��5��63   ��58      �� 59      $ 	close.png��6   5<      �� 5=   
   -   5        $ MinimizeWindow��5=      $��0��6)   $��4��66   ��5>      �� 5?      $ minimize.png��6   5A      �� 5C   
   -   5        $ ConfigruationSetting��5C      $��0��6/   $��3��6<   ��5D      �� 5E      $ setting.jpg��6   5G      �� 5K   
   $��1��6   $��2��6"    �� Orientation$ Vertical=�62   .+�5L      �� $��10 50 10 10q�6    �� TextAlignment$ Center=�5M      $��	Helvetica)�5N      $
��Wrap=�5O      $��20(�5P      $��Black"�5Q      42WELCOME TO HOTBAG WEB PRINTING CONFIGURATION SETUP5S      5T      �� 5W   
   $��2��6   $��2��6"   $ 
Horizontal=�62   $��Center=�6K   .+�5X      �� -   5        $ InstallService��5X      $��5q�6-   $��5q�68   $��40��6D   .��5Y      �� $��10q�6   $��15(�6(   	Install6?   5Z      �� 5[      -   5        $ UnInstallService��5[      $��5q�6/   $��5q�6:   $��40��6F   .��5\      �� $��10q�6   $��15(�6(   	Uninstall6A   5]      �� 5^      -   5        $ StartService��5^      $��5q�6+   $��5q�66   $��40��6B   .��5_      �� $��10q�6   $��15(�6(   Start6=   5`      �� 5a      -   5        $ StopService��5a      $��5q�6*   $��5q�65   $��40��6A   .��5b      �� $��10q�6   $��15(�6(   Stop6<   5c      �� 5d      -   5        $ d��5d      $��5q�6    $��5q�6+   $��40��67   .��5e      �� $��10q�6   $��15(�6(   Printer Setup6E   5f      �� 5g      -	   5        $ CheckServiceStatus��5g      $��5q�61   $��5q�6<   $��40��6H   .��5h      �� $��10q�6   $��15(�6(   Check Status6D   5i      5j      �� 5m   
   $��3��6   $��2��6"   $��3��62   $��0q�6D   .+�5n      �� -
   5         ��Name$ 
ActiveItem��5n   6   $	��500��6   $	��500��6)   66   5o      5p      5q      